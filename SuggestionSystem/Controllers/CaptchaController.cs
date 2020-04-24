using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SuggestionSystem.BaseSystemModel.Model.DTO;
using SuggestionSystem.Models;

namespace SuggestionSystem.Controllers
{
    public class CaptchaController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }



        #region Captcha        
        public ActionResult Captcha()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Captcha(TestDTO testDto)
        {
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != Request["inputCaptcha"].ToString())
            {
                ModelState.AddModelError("", "کپچا اشتباه است");
                return View(testDto);
            }

            return View("Index");
        }

        public string CaptchaImage(string prefix, bool noisy = true)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            //generate new question
            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);
            var captcha = string.Format("{0} + {1} = ?", a, b);

            //store answer
            Session["Captcha" + prefix] = a + b;

            //image stream
            FileContentResult img = null;

            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(130, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));

                //add noise
                if (noisy)
                {
                    int i, r, x, y;
                    var pen = new Pen(Color.Yellow);
                    for (i = 1; i < 10; i++)
                    {
                        pen.Color = Color.FromArgb(
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)));

                        r = rand.Next(0, (130 / 3));
                        x = rand.Next(0, 130);
                        y = rand.Next(0, 30);

                        gfx.DrawEllipse(pen, x - r, y - r, r, r);
                    }
                }

                //add question
                gfx.DrawString(captcha, new Font("Tahoma", 15), Brushes.Gray, 2, 3);

                //render as Jpeg
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
            }

            return System.Convert.ToBase64String(img.FileContents);
        }
        #endregion



        #region Google ReCaptcha V2
        public ActionResult GoogleReCaptchaV2()
        {
            return View();
        }


        [HttpPost]
        [ValidateGoogleCaptcha]
        public ActionResult GoogleReCaptchaV2(TestDTO testDto)
        {
            return View("Index");
        }
        #endregion



        #region Google ReCaptcha V2
        public ActionResult GoogleReCaptchaV2Ajax()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GoogleReCaptchaV2Ajax(TestDTO testDto)
        {

            const string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            const string secretKey = SiteSettings.GoogleRecaptchaSecretKey;
            var captchaResponse = Request["g-recaptcha-response"];
            var result = ValidateFromGoogle(urlToPost, secretKey, captchaResponse);


            if (result.Success)
            {
                return Json(new
                {
                    Status = true,
                });
            }

            return Json(new
            {
                Status = false,
                CaptchaStatus = "failed"
            });

        }


        private ReCaptchaResponse ValidateFromGoogle(string urlToPost, string secretKey, string captchaResponse)
        {
            //it is same method of ValidateGoogleCaptchaAttribute class

            var postData = "secret=" + secretKey + "&response=" + captchaResponse;

            var request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                streamWriter.Write(postData);

            string result;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                    result = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<ReCaptchaResponse>(result);
        }
        #endregion


        #region Google ReCaptcha V3

        #endregion


     
    }


}