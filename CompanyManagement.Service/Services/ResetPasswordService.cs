using CompanyManagement.Domain.Model;
using CompanyManagement.Service.Helper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using Service.Helpers;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class ResetPasswordService : IResetPasswordService
    {

        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly IResetPasswordRepository _iresetPasswordRepository;

        GetSingleData data = new GetSingleData();



        //-------------------------------Reset Password----------------------------------------------
        public Response Reset(ResetPasswordModel model)
        {
            data = _iresetPasswordRepository.Reset(model);
            var currentyear = DateTime.Now.Year.ToString();
            string Email = string.Empty;
            try
            {
                if (data.ModelReset != null)
                {
                    if (data.ModelReset.UserName != null || data.ModelReset.UserName != "" && data.ModelReset.UserGuid != "" && data.ModelReset.UserName != null)
                    {
                        string template = string.Empty;
                        template = "You forgot your password, no worries, it happens to the best of us. Reset your password for the account with user details as mentioned below.";

                        Email = "<div>"
                    + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">"
                    + "<tbody>"
                        + "<tr>"
                            + "<td height=\"40\"></td>"
                        + "</tr>"
                        + "<tr>"
                            + "<td valign=\"top\" align=\"center\">"
                            + "<table width=\"700\" bgcolor=\"#FFFFFF\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" name=\"intro\">"
                                + "<tbody>"
                                    + "<tr>"
                                        + "<td>"
                                            + "<table width=\"700\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"font-family:Proxima N W15 Thin Reg,Helvetica,Arial,sans-serif;font-size:15px;color:#313437;\">"
                                                + "<tbody>"
                                                    + "<tr>"
                                                        + "<td height = \"20\"></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\"><font style=\"font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;font-size:40px;color:#ff5c00;\"> Hello!</font></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\" style=\"padding:20px 0px 0px 0px;\"><font style=\"font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;font-size:20px;color:#313437;line-height: 28px;\"> " + template + "</font></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\" style=\"padding:20px 0px 0px 0px;\"><font style=\"line-height:30px;font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;color:#313437; font-size:16px;;line-height: 28px;\"> Username: " + data.ModelReset.UserName + "</font></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\" style=\"padding:20px 0px 0px 0px;\"><font style=\"line-height:30px;font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;color:#313437; font-size:16px;;line-height: 28px;\"> Click on the link below to reset your password.</font></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\"><font style=\"font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;font-size:20px;color:#313437\"><a href=" + "https://localhost:44371/resetpassword/" + data.ModelReset.UserGuid + " target =\"_blank\">" + "UrlLink" + "</a></font></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\" style=\"padding:20px 0px 0px 0px;\"><font style=\"line-height:30px;font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;color:#313437; font-size:16px;line-height: 28px;\"> This reset password link will expire in 24 hours. If you continue having any issues signing in, please feel free to contact us at support@subsource.com.</font></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\" style=\"padding:20px 0px 0px 0px;\"><font style=\"line-height:30px;font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;color:#313437; font-size:16px;\"> Your Friends at SubSource</font></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td height=\"25\" align=\"center\" style=\"padding:0px 0px 0px 0px;\"><hr style=\"height:1px; background-color:#CCC; border:none;\"></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\" style=\"padding:10px 0px 0px 0px;\"><font style=\"font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;color:#313437; font-size:16px;\"> If you didn't request to update your password, don't worry, you can safely disregard this email. </font></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td height=\"25\" align=\"center\" style=\"padding:0px 0px 0px 0px;\"><hr style=\"height:1px; background-color:#CCC; border:none;\"></td>"
                                                    + "</tr>"
                                                    + "<tr>"
                                                        + "<td align=\"left\" style=\"padding:0px 0px 0px 0px;\"><font style=\"line-height:10px;font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;color:#313437; font-size:12px;\">©" + currentyear + "SubSource LLC. All rights reserved. U.S.</font></td>"
                                                    + "</tr>"
                                                + "</tbody>"
                                            + "</table>"
                                        + "</td>"
                                    + "</tr>"
                                + "</tbody>"
                            + "</table></td>"
                    + "</tr>"
                    + "</tbody>"
                    + "</table>"
                    + "<table>"
                        + "<tbody>"
                            + "<tr>"
                                + "<td height=\"40\"></td>"
                            + "</tr>"
                        + "</tbody>"
                    + "</table>"
                    + "</div> ";

                    }


                    //+"<tr>"
                    //    + "<td align=\"left\" style=\"padding:20px 0px 0px 0px;\"><font style=\"line-height:30px;font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;color:#313437; font-size:16px;;line-height: 28px;\"> If the url above doesn't works, Please try copy and pasting the url in your bowser's address bar.</font></td>"
                    //+ "</tr>"

                    data.ModelReset.EmailPdf = Email;


                    //+"<tr>"
                    //    + "<td align=\"left\" style=\"padding:20px 0px 0px 0px;\"><font style=\"line-height:30px;font-family:Proxima N W15 Light,Helvetica,Arial,sans-serif;color:#313437; font-size:16px;;line-height: 28px;\"> If the url above doesn't works, Please try copy and pasting the url in your bowser's address bar.</font></td>"
                    //+ "</tr>"
                }

                bool isSend = EmailTemplate.Gmail("bwssapna@gmail.com", "Reset Password", Email);
                if (isSend == true)
                {
                    data.Status = 1;
                    data.Message = "Email Notification send successfully.";

                }
                else
                {
                    data.Status = 0;
                    data.Message = "Email Not Found";
                }
                return data;
            }

            catch (Exception ex)
            {
                data.Status = 0;
                data.Message = "Email Not Found";
                return data;
            }
            //return data;
        }



        //--------------------------------Save Update Password -------------------------------- -------???

        public Response SaveUpdate(ChangePasswordModel changemodel)
        {
            try
            {
                obj = EncryptHelper.Get_EncryptedPassword(obj, changemodel.Password);
                changemodel.PassKey = obj.Value;
                changemodel.SaltKey = obj.SaltKey;
                changemodel.SaltKeyIV = obj.SaltKeyIV;


                return _iresetPasswordRepository.SaveUpdate(changemodel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
