// Controllers for the Models BlueCard and Vessel, providing endpoints for CRUD operations and data retrieval.

using Microsoft.AspNetCore.Mvc;
using vesselDataService.Models;

namespace vesselDataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VesselsController : ControllerBase
    {
        private static List<Vessel> _vessels = new List<Vessel>
        {
            new Vessel
            {
                ImoNumber = 9851945,
                VesselName = "ARKLOW ACCORD",
                Member = "ARKLOW SHIPPING ULC",
                RegisteredOwner = "Abbey Shipping Limited",
                GrossTonnage = 5078,
                Flag = "IRELAND",
                Year = 2019,
                ShipType = "GENERAL CARGO SHIP",
                Insurer = "NorthStandard EU DAC",
                Status = "On Risk",
                BlueCards = new List<BlueCard>
                {
                    new BlueCard
                    {
                        Id = 1,
                        VesselImo = 9851945,
                        CardType = "Bunker Blue Card",
                        IssueDate = new DateTime(2026, 2, 20),
                        ExpiryDate = new DateTime(2027, 2, 20)
                    },
                    new BlueCard
                    {
                        Id = 2,
                        VesselImo = 9851945,
                        CardType = "Wreck Blue Card",
                        IssueDate = new DateTime(2026, 2, 20),
                        ExpiryDate = new DateTime(2027, 2, 20)
                    },
                    new BlueCard
                    {
                        Id = 3,
                        VesselImo = 9851945,
                        CardType = "MLC Certificate - Regulation 2.5.2 Standard A2.5.2",
                        IssueDate = new DateTime(2026, 2, 20),
                        ExpiryDate = new DateTime(2027, 2, 20)
                    },
                    new BlueCard
                    {
                        Id = 4,
                        VesselImo = 9851945,
                        CardType = "MLC Certificate - Regulation 4.2 Standard A4.2.1",
                        IssueDate = new DateTime(2026, 2, 20),
                        ExpiryDate = new DateTime(2027, 2, 20)
                    }
                }
            }
        };

        // GET /vessels
        [HttpGet]
        public ActionResult<List<Vessel>> GetAll()
        {
            return Ok(_vessels);
        }

        // GET /vessels/{IMO}
        [HttpGet("{IMO}")]
        public ActionResult<Vessel> GetById(int IMO)
        {
            var vessel = _vessels.FirstOrDefault(v => v.ImoNumber == IMO);
            if (vessel == null)
            {
                return NotFound();
            }
            return Ok(vessel);
        }

        // POST /vessels
        [HttpPost]
        public ActionResult<Vessel> Add(Vessel vessel)
        {
            if (_vessels.Any(v => v.ImoNumber == vessel.ImoNumber))
            {
                return Conflict("A vessel with this IMO number already exists");
            }
            _vessels.Add(vessel);
            return CreatedAtAction(nameof(GetById), new { IMO = vessel.ImoNumber }, vessel);
        }

        // PUT /vessels/{IMO}/status
        [HttpPut("{IMO}/status")]
        public ActionResult UpdateStatus(int IMO, [FromBody] string status)
        {
            var vessel = _vessels.FirstOrDefault(v => v.ImoNumber == IMO);
            if (vessel == null)
            {
                return NotFound();
            }
            vessel.Status = status;
            return NoContent();
        }


        // POST /vessels/{IMO}/bluecards
        [HttpPost("{IMO}/bluecards")]
        public ActionResult<BlueCard> AddBlueCard(int IMO, BlueCard blueCard)
        {
            var vessel = _vessels.FirstOrDefault(v => v.ImoNumber == IMO);
            if (vessel == null)
            {
                return NotFound();
            }
            blueCard.Id = vessel.BlueCards.Any() ? vessel.BlueCards.Max(b => b.Id) + 1 : 1;
            blueCard.VesselImo = IMO;
            vessel.BlueCards.Add(blueCard);
            return CreatedAtAction(nameof(GetById), new { IMO = vessel.ImoNumber }, blueCard);
        }
    }
}

