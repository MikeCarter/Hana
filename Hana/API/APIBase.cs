using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.IO;
using System.Drawing;
using CookComputing.XmlRpc;
using System.Drawing.Imaging;

namespace Hana.API
{
    public class APIBase:XmlRpcService
    {

        IAuthentication _auth;
        public APIBase(){
            _auth = new ASPMembershipAuthentication();
        }
        public APIBase(IAuthentication auth){
            _auth = auth;
        }
        public bool ValidateUser(string username, string password)
        {
            return _auth.UserIsValid(username, password);
        }
        public static byte[] ConvertImageToByteArray(Image imageToConvert, ImageFormat formatOfImage)
        {
            byte[] Ret;
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                Ret = ms.ToArray();
            }
            return Ret;
        }

        public static Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray != null)
            {
                MemoryStream ms = new MemoryStream(byteArray, 0,
                byteArray.Length);
                ms.Write(byteArray, 0, byteArray.Length);
                return Image.FromStream(ms, true);
            }
            return null;
        }
    }
}
