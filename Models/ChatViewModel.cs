﻿using OmniTalks.Models.Domein;
using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Models
{
    public class ChatViewModel
    {
        public User Reciever { get; set; } = null!;
    }
}
