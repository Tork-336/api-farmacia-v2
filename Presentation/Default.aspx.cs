﻿using Logic.User;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using SimpleCrypto;
using System.Web.Security;

namespace Presentation
{
    public partial class Default : System.Web.UI.Page
    {
        UserLog objUserLog = new UserLog();
        User1 objUser = new User1();
        private string correo;
        private string contrasena;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtGuardar_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            correo = TBCorreo.Text;
            contrasena = TBContrasena.Text;
            objUser = objUserLog.ShowUsersMail(correo);//Busca el correo del usuario
            if (objUser != null)
            {
                string passEncryp = cryptoService.Compute(contrasena, objUser.Salt);
                if (cryptoService.Compare(objUser.Contrasena, passEncryp))
                {
                    FormsAuthentication.RedirectFromLoginPage("Index.aspx", true);
                    TBCorreo.Text = "";
                    TBContrasena.Text = "";

                }
                else
                {
                    LblMsg.Text = "Correo o Contraseña Incorrectos!";
                }
            }
            else
            {
                LblMsg.Text = "Correo o Contraseña Incorrectos!";
            }
        }
    }
}