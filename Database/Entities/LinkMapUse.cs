﻿namespace ShorteningWebService.Database.Entities
{
    public class LinkMapUse
    {
        public int Id { get; set; }
        public Guid LinkMap { get; set; }
        public DateTime When { get; set; }
    }
}