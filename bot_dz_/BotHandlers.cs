using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace bot_dz_
{
    internal static class BotHandlers
    {
        private static void Razgovor(string msg)
        {
            if (msg.Length >= 3 && msg.Length <= 7)
            {
                //await botClient.SendTextMessageAsync(message.Chat, "Введи имя состоящие из 4-15 символов пожалуйста!");
                return;
            }
        }
        public async static Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            if (update.Message is not { } message)
                return;

            if (message.Text is not { } messageText)
                return;
            var chatId = message.Chat.Id;






            switch (message.Text.ToLower())
            {
                case "/start":
                    await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать в наше подземелье, перед тобой появятся 8 двери и тебе надо будет выбрать 1 из них");
                    return;
                default:
                    break;
            }
            if (message.Text == "1")
            {
                await botClient.SendTextMessageAsync(message.Chat, " вас ждал злой Алексей, который выебал вас за то что вы не сдали зачет ");
                return;
            }
            else if (message.Text == "2")
            {
                await botClient.SendTextMessageAsync(message.Chat, " на вас напали гремлины");
                return;
            }
            else if (message.Text == "3")
            {
                await botClient.SendTextMessageAsync(message.Chat, " вы нашли сундук с деньгами!");
                return;
            }
            else if (message.Text == "4")
            {
                await botClient.SendTextMessageAsync(message.Chat, " вы выиграли автомобиль!");
                return;
            }
            else if (message.Text == "5")
            {
                await botClient.SendTextMessageAsync(message.Chat, " с вас косарь!");
                return;
            }
            else if (message.Text == "6")
            {
                await botClient.SendTextMessageAsync(message.Chat, " !");
                return;
            }
           
            else
            {
                await botClient.SendTextMessageAsync(message.Chat, "Неизвестная команда!");
                return;
            }


            

           
















        }
        public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }


    }
}