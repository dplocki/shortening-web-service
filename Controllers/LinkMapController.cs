﻿using Microsoft.AspNetCore.Mvc;

namespace ShorteningWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkMapController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;

        public LinkMapController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet]
        [Route("NewID")]
        public Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }

        [HttpGet]
        public IEnumerable<LinkMap> Get()
        {
            return databaseContext.LinkMaps.ToArray();
        }
    }
}
