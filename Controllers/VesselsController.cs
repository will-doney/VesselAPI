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
                Id = 1,
                ImoNumber = "9851945",
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
                        VesselId = 1,
                        CardType = "Bunker Blue Card",
                        IssueDate = new DateTime(2026, 2, 20),
                        ExpiryDate = new DateTime(2027, 2, 20)
                    },
                    new BlueCard
                    {
                        Id = 2,
                        VesselId = 1,
                        CardType = "Wreck Blue Card",
                        IssueDate = new DateTime(2026, 2, 20),
                        ExpiryDate = new DateTime(2027, 2, 20)
                    },
                    new BlueCard
                    {
                        Id = 3,
                        VesselId = 1,
                        CardType = "MLC Certificate - Regulation 2.5.2 Standard A2.5.2",
                        IssueDate = new DateTime(2026, 2, 20),
                        ExpiryDate = new DateTime(2027, 2, 20)
                    },
                    new BlueCard
                    {
                        Id = 4,
                        VesselId = 1,
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

        // GET /vessels/{id}
        [HttpGet("{id}")]
        public ActionResult<Vessel> GetById(int id)
        {
            var vessel = _vessels.FirstOrDefault(v => v.Id == id);
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
            vessel.Id = _vessels.Max(v => v.Id) + 1;
            _vessels.Add(vessel);
            return CreatedAtAction(nameof(GetById), new { id = vessel.Id }, vessel);
        }

        // PUT /vessels/{id}/status
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var vessel = _vessels.FirstOrDefault(v => v.Id == id);
            if (vessel == null)
            {
                return NotFound();
            }
            vessel.Status = status;
            return NoContent();
        }
    }
}