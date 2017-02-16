using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Task_4.Models;
using Task_4.Data_Transfer_Object;
using System.Web.Http.Cors;

namespace Task_4.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class PhonesController : ApiController
    {
        private Task_4Context db = new Task_4Context();

        // GET: api/Phones
        //[Route("api/Phones")]
        public IList<PhoneShortInformation> GetPhones()
        {
            var rQuery = from p in db.Phones.Include(s => s.Images)
                         select new PhoneShortInformation()
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Description = p.Description,
                             MainImageURL = p.Images.Where(s => s.PhoneID == p.ID).FirstOrDefault().ImageURL
                         };

            var phones = rQuery.ToList();

            foreach(var item in phones)
            {
                item.Description = SplitDesc(item.Description);
            }

            return phones;
        }

        private string SplitDesc(string Description)
        {
            string[] arrString = Description.Split(' ');
            string outValue = "";
            foreach(var item in arrString)
            {
                if (outValue.Length < 50)
                    outValue = outValue + " " + item;

                else
                    break;
            }

            outValue = outValue + "...";
            return outValue;
        }

        // GET: api/Phones/5
        [ResponseType(typeof(PhoneDTO))]
        public async Task<IHttpActionResult> GetPhone(int id)
        {
            //db.Configuration.ProxyCreationEnabled = false;

            var searchedPhone = await db.Phones
                .Include(s => s.Availabilities)
                .Include(s => s.CameraFeatures)
                .Include(s => s.Images)
                .Include(s => s.PlatformParameters)
                .Where(p => p.ID == id)
                .SingleOrDefaultAsync();

            if(searchedPhone == null)
            {
                return NotFound();
            }

            var phone = new PhoneDTO()
            {
                AdditionalFeatures = searchedPhone.AdditionalFeatures,
                BatteryStandbyTime = searchedPhone.BatteryStandbyTime,
                BatteryTalkTime = searchedPhone.BatteryTalkTime,
                BatteryType = searchedPhone.BatteryType,
                CameraPrimary = searchedPhone.CameraPrimary,
                ConnectivityBluetooth = searchedPhone.ConnectivityBluetooth,
                ConnectivityCell = searchedPhone.ConnectivityCell,
                ConnectivityGPS = searchedPhone.ConnectivityGPS,
                ConnectivityInfrared = searchedPhone.ConnectivityInfrared,
                ConnectivityWiFi = searchedPhone.ConnectivityWiFi,
                Description = searchedPhone.Description,
                DisplayScreenResolution = searchedPhone.DisplayScreenResolution,
                DisplayScreenSize = searchedPhone.DisplayScreenSize,
                DisplayTouchScreen = searchedPhone.DisplayTouchScreen,
                HardwareAccelerometer = searchedPhone.HardwareAccelerometer,
                HardwareAudioJack = searchedPhone.HardwareAudioJack,
                HardwareCPU = searchedPhone.HardwareCPU,
                HardwareFMRadio = searchedPhone.HardwareFMRadio,
                HardwarePhysicalKeyboard = searchedPhone.HardwarePhysicalKeyboard,
                HardwareUSB = searchedPhone.HardwareUSB,
                Name = searchedPhone.Name,
                Width = searchedPhone.Width,
                Height = searchedPhone.Height,
                Depth = searchedPhone.Depth,
                Weight = searchedPhone.Weight,
                StorageFlash = searchedPhone.StorageFlash,
                StorageRAM = searchedPhone.StorageRAM,
                PlatformType = searchedPhone.PlatformParameters.PlatformType,
                PlatrormVersion = searchedPhone.PlatformParameters.PlatrormVersion,
                PlatformUI = searchedPhone.PlatformParameters.PlatformUI,

                Availabilities = ToListFromRequaest(searchedPhone.Availabilities),
                CameraFeatures = ToListFromRequaest(searchedPhone.CameraFeatures),
                Images = ToListFromRequaest(searchedPhone.Images)
            };

            return Ok(phone);
        }

        private List<string> ToListFromRequaest(ICollection<PhoneAvailability> list)
        {
            var outList = new List<string>();

            foreach(var item in list)
            {
                outList.Add(item.Availability);
            }

            return outList;
        }

        private List<string> ToListFromRequaest(ICollection<PhoneCameraFeature> list)
        {
            var outList = new List<string>();

            foreach (var item in list)
            {
                outList.Add(item.CameraFeature);
            }

            return outList;
        }

        private List<string> ToListFromRequaest(ICollection<PhoneImage> list)
        {
            var outList = new List<string>();

            foreach (var item in list)
            {
                outList.Add(item.ImageURL);
            }

            return outList;
        }

        // PUT: api/Phones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhone(int id, Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phone.ID)
            {
                return BadRequest();
            }

            db.Entry(phone).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Phones
        [ResponseType(typeof(PhoneDTO))]
        public async Task<IHttpActionResult> PostPhone(PhoneDTO phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Phones.Add(phone);
            //await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = phone.ID }, phone);
        }

        // DELETE: api/Phones/5
        [ResponseType(typeof(Phone))]
        public async Task<IHttpActionResult> DeletePhone(int id)
        {
            Phone phone = await db.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            db.Phones.Remove(phone);
            await db.SaveChangesAsync();

            return Ok(phone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneExists(int id)
        {
            return db.Phones.Count(e => e.ID == id) > 0;
        }
    }
}