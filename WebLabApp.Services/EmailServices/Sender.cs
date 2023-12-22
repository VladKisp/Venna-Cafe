using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebAppLab.Services.EmailServices
{
	public class Sender : ISender
	{
		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var API_KEY = "SenGrid_API_Key";
			//не зміг знайти безкоштовне апі для даних дій
			var client = new SendGridClient(API_KEY);
			var sendFrom = new EmailAddress("vladtym876@gmail.com", "User");
			var sendTo = new EmailAddress(email, "User");
			var massage = MailHelper.CreateSingleEmail(sendFrom, sendTo, subject, message, $"<strong>{message}</strong>");
			var response = await client.SendEmailAsync(massage);
		}
	}
}
