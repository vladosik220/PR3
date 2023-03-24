class SmsMessage
{
    private string messageTXT;
    private double basePrice;
    private double extraCharPrice;
    private int maxLength;
    private double price;

    public SmsMessage(string messageTXT, double basePrice, double extraCharPrice, int maxLength)
    {
        this.messageTXT = messageTXT;
        this.basePrice = basePrice;
        this.extraCharPrice = extraCharPrice;
        this.maxLength = maxLength;

        CalculatePrice();
    }

    public string MessageTXT
    {
        get { return messageTXT; }
        set 
        {
            if (value.Length > maxLength) // обрезаем до максимальной длины maxLength
            {
                messageTXT = value.Substring(0, maxLength);
            }
            else
            {
                messageTXT = value;
            }

            CalculatePrice(); // пересчитываем стоимость сообщения
        }
    }

    public double Price
    {
        get { return price; }
    }

    private void CalculatePrice()
    {
        int length = messageTXT.Length;

        if (length <= maxLength)
        {
            price = basePrice;
        }
        else
        {
            int extraChars = length - maxLength;
            price = basePrice + (extraChars * extraCharPrice);
        }
    }
}

// отправка

SmsMessage message = new SmsMessage("текст сообщения", 1.5, 0.5, 250); // создаем объект класса с заданными параметрами
message.MessageTXT = "новый текст сообщения"; // изменяем текст сообщения
double price = message.Price; // получаем стоимость сообщения
// отправка сообщения
// ...
