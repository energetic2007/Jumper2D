using System;

public class EventPublisher
{
    public Action CreatePlayerDieEvent;
    public event Action OnPlayerDie
    {
        add
        {
            CreatePlayerDieEvent += value;
        }

        remove
        {
            CreatePlayerDieEvent -= value;
        }
    }


    private static EventPublisher instance;

    private EventPublisher()
    { }
    public static EventPublisher getInstance()
    {
        if (instance == null)
            instance = new EventPublisher();
        return instance;
    }

}

