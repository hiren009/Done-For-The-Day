using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace DoneForTheDay
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		#region Events

		private void btnSendWorkMail_Click(object sender, EventArgs e)
		{
			new Task(() => { SendWorkEmail(); }).Start();
		}

		private void btnLockPC_Click(object sender, EventArgs e)
		{
			Process.Start(Helper.GetAppSettingValue("LockPcDllPath"), "user32.dll,LockWorkStation");
		}

		private void btnShutdownPC_Click(object sender, EventArgs e)
		{
			Process.Start("Shutdown", "-s -t 10");
		}

		private void btnRunCCleaner_Click(object sender, EventArgs e)
		{
			Process.Start(Helper.GetAppSettingValue("CCleanerPath"), "\auto");
		}

		#endregion

		#region Handlers

		private void SendWorkEmail()
		{
			try
			{
				//Get email content
				var cFileName = Helper.GetAppSettingValue("TaskFileLocation");
				var mailContent = new StringBuilder();

				var content = System.IO.File.ReadAllLines(cFileName);

				mailContent.Append(@"<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:w=""urn:schemas-microsoft-com:office:word"" xmlns:m=""http://schemas.microsoft.com/office/2004/12/omml"" xmlns=""http://www.w3.org/TR/REC-html40""><head><meta http-equiv=Content-Type content=""text/html; charset=us-ascii""><meta name=Generator content=""Microsoft Word 15 (filtered medium)""><style><!--
/* Font Definitions */
@font-face
	{font-family:""Cambria Math"";
	panose-1:2 4 5 3 5 4 6 3 2 4;}
@font-face
	{font-family:Calibri;
	panose-1:2 15 5 2 2 2 4 3 2 4;}
@font-face
	{font-family:Verdana;
	panose-1:2 11 6 4 3 5 4 4 2 4;}
/* Style Definitions */
p.MsoNormal, li.MsoNormal, div.MsoNormal
	{margin:0in;
	margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:""Calibri"",sans-serif;}
a:link, span.MsoHyperlink
	{mso-style-priority:99;
	color:#0563C1;
	text-decoration:underline;}
a:visited, span.MsoHyperlinkFollowed
	{mso-style-priority:99;
	color:#954F72;
	text-decoration:underline;}
p.msonormal0, li.msonormal0, div.msonormal0
	{mso-style-name:msonormal;
	mso-margin-top-alt:auto;
	margin-right:0in;
	mso-margin-bottom-alt:auto;
	margin-left:0in;
	font-size:12.0pt;
	font-family:""Times New Roman"",serif;}
span.EmailStyle18
	{mso-style-type:personal;
	font-family:""Calibri"",sans-serif;
	color:windowtext;}
span.EmailStyle19
	{mso-style-type:personal;
	font-family:""Calibri"",sans-serif;
	color:#1F497D;}
span.EmailStyle20
	{mso-style-type:personal;
	font-family:""Calibri"",sans-serif;
	color:#1F497D;}
span.EmailStyle21
	{mso-style-type:personal;
	font-family:""Calibri"",sans-serif;
	color:#1F497D;}
span.EmailStyle22
	{mso-style-type:personal;
	font-family:""Calibri"",sans-serif;
	color:#1F497D;}
span.EmailStyle23
	{mso-style-type:personal;
	font-family:""Calibri"",sans-serif;
	color:#1F497D;}
span.EmailStyle24
	{mso-style-type:personal-reply;
	font-family:""Calibri"",sans-serif;
	color:#1F497D;}
.MsoChpDefault
	{mso-style-type:export-only;
	font-size:10.0pt;}
@page WordSection1
	{size:8.5in 11.0in;
	margin:1.0in 1.0in 1.0in 1.0in;}
div.WordSection1
	{page:WordSection1;}
--></style><!--[if gte mso 9]><xml>
<o:shapedefaults v:ext=""edit"" spidmax=""1026"" />
</xml><![endif]--><!--[if gte mso 9]><xml>
<o:shapelayout v:ext=""edit"">
<o:idmap v:ext=""edit"" data=""1"" />
</o:shapelayout></xml><![endif]--></head>
<body lang=EN-US link=""#0563C1"" vlink=""#954F72""><div class=WordSection1><p class=MsoNormal>Hi<o:p></o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal>Following is my today&#8217;s work report.<o:p></o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p>
<table class=MsoNormalTable border=1 cellspacing=0 cellpadding=0 style='border-collapse:collapse;border:none'>
");

				foreach (var itmWorkItem in content)
				{
					if (itmWorkItem.Trim() != "")
					{
						var cSplitted = itmWorkItem.Trim().Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

						string cProjectName = "";
						string cWorkDesc = "";

						if (cSplitted.Length > 1)
						{
							cProjectName = cSplitted[0].Trim();
							cWorkDesc = cSplitted[1].Trim();
						}
						else
						{
							cWorkDesc = cSplitted[0].Trim();
						}

						mailContent.AppendFormat(@"<tr style='height:15.95pt'><td width=197 valign=top style='width:148.1pt;border:solid windowtext 1.0pt;padding:0in 5.4pt 0in 5.4pt;height:15.95pt'><p class=MsoNormal><b>
{0}
<o:p></o:p></b></p></td><td width=569 valign=top style='width:426.65pt;border:solid windowtext 1.0pt;border-left:none;padding:0in 5.4pt 0in 5.4pt;height:15.95pt'><p class=MsoNormal><span style='color:#1F497D'>
{1}
<o:p></o:p></span></p></td></tr>", cProjectName, cWorkDesc);
					}
				}

				mailContent.Append(@" </table>
<p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><span style='font-size:8.0pt;font-family:""Arial"",sans-serif;color:black'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='font-size:8.0pt;font-family:""Arial"",sans-serif;color:black'>Thanks &amp; Regards,</span><span style='color:black'><o:p></o:p></span></p><p class=MsoNormal><b><span style='font-size:9.0pt;font-family:""Verdana"",sans-serif;color:#333333'>&nbsp;</span></b><span style='color:black'><o:p></o:p></span></p><p class=MsoNormal><b><span style='font-size:9.0pt;font-family:""Verdana"",sans-serif;color:#333333'>Your Name</span></b><span style='color:black'><o:p></o:p></span></p><p class=MsoNormal><b><span style='font-size:7.0pt;font-family:""Verdana"",sans-serif;color:#595959'>Your Designation</span></b><span style='color:black'><o:p></o:p></span></p><p class=MsoNormal><b><span style='font-size:9.0pt;font-family:""Verdana"",sans-serif;color:#5B8F22'>Company Name</span></b><span style='font-size:10.0pt;color:black'>| </span><a href=""mailto:emailAddress"" target=""_blank""><span style='font-size:10.0pt'>Your@email.here</span></a><span style='font-size:10.0pt;color:#1F497D'> </span><span style='font-size:10.0pt;color:black'>|</span><span style='color:black'> </span><a href=""http://www.yourcompanyName.here/"" target=""_blank""><span style='font-size:10.0pt'>www.yourCompanyName.here</span></a><span style='color:black'><o:p></o:p></span></p><p class=MsoNormal><span style='font-size:8.0pt;color:#A6A6A6'>NOTICE: The contents of this message, together with any attachments, are intended only for the use of the person(s) to which they are addressed and may contain confidential and/or privileged information. Further, any medical information herein is confidential and protected by law. It is unlawful for unauthorized persons to use, review, copy, disclose, or disseminate confidential medical information. If you are not the intended recipient, immediately advise the sender and delete this message and any attachments. Any distribution, or copying of this message, or any attachment, is prohibited.</span><o:p></o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");


				//Start configuring mail
				Outlook.Application oApp = new Outlook.Application();
				Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

				oMailItem.To = Helper.GetAppSettingValue("MailTo");
				oMailItem.CC = Helper.GetAppSettingValue("MailToCC");

				oMailItem.Subject = string.Format("Work Report: {0}", DateTime.Now.ToString("dd-MMMM-yyyy"));

				oMailItem.HTMLBody = mailContent.ToString();

				// body, bcc etc...
				oMailItem.Display(true);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		#endregion

	}
}
