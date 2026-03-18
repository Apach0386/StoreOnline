using System;
using System.Collections.Generic;
using System.Text;

namespace PopeliuhaLessons
{
    internal class FileName
    {
        [Theory]
        [InlineData("MessageName", "[FirstName]Body" + TemplateMessageConstants.SmsOptoutInformation, "[FirstName] Body" + TemplateMessageConstants.SmsOptoutInformation)]
        [InlineData("MessageName", "Message[FirstName]" + TemplateMessageConstants.SmsOptoutInformation, "Message [FirstName]" + TemplateMessageConstants.SmsOptoutInformation)]
        [InlineData("MessageName", "Message[FirstName]Body" + TemplateMessageConstants.SmsOptoutInformation, "Message [FirstName] Body" + TemplateMessageConstants.SmsOptoutInformation)]
        [InlineData("MessageName", "[FirstName]\nBody" + TemplateMessageConstants.SmsOptoutInformation, "[FirstName]\nBody" + TemplateMessageConstants.SmsOptoutInformation)]
        [InlineData("MessageName", "Message\n[FirstName]" + TemplateMessageConstants.SmsOptoutInformation, "Message\n[FirstName]" + TemplateMessageConstants.SmsOptoutInformation)]
        [InlineData("MessageName", "Message [FirstName] Body" + TemplateMessageConstants.SmsOptoutInformation, "Message [FirstName] Body" + TemplateMessageConstants.SmsOptoutInformation)]
        [Trait("Category", "TemplateMessages")]
        public async Task UpdateSmsTemplateMessageAsync_WhenMessageContainsMergeTagWithoutRequiredSpaces_ShouldNormalizeMessageBody(
    string messageName,
    string inputMessageBody,
    string expectedMessageBody)
        {
            var service = CreateService();

            var smsMessageRequestDto = new SmsTemplateMessageRequestDto()
            {
                Name = messageName,
                Message = inputMessageBody
            };

            var response = await service.UpdateTemplateMessageAsync(TestMessageId, smsMessageRequestDto);

            Assert.Equal(TestMessageId, response.Id);
            Assert.Equal(messageName, response.Name);
            Assert.Equal(expectedMessageBody, response.Body);
        }
    }
}
