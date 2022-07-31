using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using bot_dz_;


var botClient = new TelegramBotClient("5432430037:AAETs2pw19OaP3VfjXDix7APmZhEbjUe-BQ");

using var cts = new CancellationTokenSource();  //Создаёт объект для остановки

var receiverOptions = new ReceiverOptions //задаём реакцию,те на какие сообщения реагирует бот
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

botClient.StartReceiving(
updateHandler: BotHandlers.HandleUpdateAsync,
pollingErrorHandler: BotHandlers.HandlePollingErrorAsync,
receiverOptions: receiverOptions,
cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine("Bot started");
Console.WriteLine($"Start listening for @{me.Username}");
Console.WriteLine("Press enter for stop");
Console.ReadKey();

cts.Cancel();

Console.WriteLine("Bot stopped");