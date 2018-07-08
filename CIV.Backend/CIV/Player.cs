using System;

namespace CIV
{
    public class Player
    {
        public Player(string username)
        {
            Id = Guid.NewGuid();
            Username = username;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
    }
}
