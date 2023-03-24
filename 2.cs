class SmsMessage
{
    private string messageTXT;
    private double price;

    public string MessageTXT
    {
        get { return messageTXT; }
        set 
        {
            if (value.Length > 250) // обрезаем до максимальной длины 250 символов
            {
                messageTXT = value.Substring(0, 250);
            }
            else
            {
                messageTXT = value;
            }
        }
    }

    public double Price
    {
        get { return price; }
    }

    public void CalculatePrice()
    {
        int length = messageTXT.Length;

        if (length <= 65)
        {
            price = 1.5;
        }
        else if (length > 65 && length <= 250)
        {
            int extraChars = length - 65;
            price = 1.5 + (extraChars * 0.5);
        }
        else // длина сообщения больше 250 символов, обрезаем до максимальной длины
        {
            messageTXT = messageTXT.Substring(0, 250);
            price = 1.5 + ((250 - 65) * 0.5);
        }
    }
}


// отправка

SmsMessage message = new SmsMessage();
message.MessageTXT = "текст сообщения";
message.CalculatePrice();

// отправка сообщения
// ...
