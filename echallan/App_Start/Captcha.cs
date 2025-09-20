using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace WebApplication1.App_Start
{
    public class Captcha
    {
        public int expectedAnswer;
        public int getAnswer()
        {
            return expectedAnswer;
        }
        public string GenerateArithmeticCaptcha()
        {
            Random random = new Random();

            int operand1 = random.Next(1, 11); // Random number between 1 and 10
            int operand2 = random.Next(1, 11); // Random number between 1 and 10
            char operation = '+';
            

            string captchaExpression = $"{operand1} {operation} {operand2}";
            expectedAnswer= operand1+operand2;

            // Store the correct answer in a hidden field for validation later
            /* HttpContext.Current.Session["CaptchaResult"] = result;*/

            // Create and save the arithmetic expression image
string captchaImagePath = SaveCaptchaImage(captchaExpression);
            return captchaImagePath;
        }

        private string SaveCaptchaImage(string text)
        {
            int width = 200;
            int height = 60;

            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = new Rectangle(0, 0, width, height);
                    LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightBlue, Color.LightGreen, LinearGradientMode.ForwardDiagonal);
                    graphics.FillRectangle(brush, rect);

                    //graphics.FillRectangle(Brushes.White, 0, 0, width, height);

                    Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
                    graphics.DrawString(text, font, Brushes.Black, 10, 10);
                    
                        Random random = new Random();
                        Pen pen = new Pen(Color.Black, 2);

                        // Draw random lines
                        for (int i = 0; i < 8; i++) // You can adjust the number of lines
                        {
                            int x1 = random.Next(width);
                            int y1 = random.Next(height);
                            int x2 = random.Next(width);
                            int y2 = random.Next(height);
                            graphics.DrawLine(pen, x1, y1, x2, y2);
                        }
                    





                    // Save the image to a file
                    string virtualPath = "captcha.png";
                    Debug.WriteLine(virtualPath);
                    // Get the physical file path for captcha.png
                    string imagePath = HttpContext.Current.Server.MapPath(virtualPath);
                    Debug.WriteLine(imagePath);

                    // Get the directory of the file
                    string directoryPath = Path.GetDirectoryName(imagePath);
                    Debug.WriteLine(directoryPath);

                    // Check if the directory exists, if not, create it
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    bitmap.Save(imagePath, ImageFormat.Png);

                    return imagePath;
                }
            }
        }

    }
}