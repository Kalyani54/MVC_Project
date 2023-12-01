using MVC_TravelProject.Models;

namespace MVC_TravelProject.Repository
{
    public class TravelRepository:ITravelRepository
    {
        private readonly employeeTravelContext _context;

        public TravelRepository(employeeTravelContext context)
        {
            _context = context;
        }
        public IEnumerable<TravelRequest> GetRequests()
        {
            return _context.TravelRequests;
        }

        public void RaiseRequest(TravelRequest req)
        {
            if (req != null)
            {
                req.ApproveStatus = "Pending";
                req.BookingStatus = "Pending";
                req.CurrentStatus = "Open";
                _context.TravelRequests.Add(req);
                _context.SaveChanges();
            }

        }

		public void DeleteRequest(int id)
        {
            TravelRequest? req= _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);
            if(req != null)
            {
                _context.TravelRequests.Remove(req);
                _context.SaveChanges();
            }
        }

		public TravelRequest GetRequestById(int id)
		{
			TravelRequest? travelRequest = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);
			return travelRequest;
		}
		public void UpdateRequest(TravelRequest travelrequest, int id)
		{
			TravelRequest? req_old = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);
			if (req_old != null)
			{

				req_old.FromLocation = travelrequest.FromLocation;
				req_old.ToLocation = travelrequest.ToLocation;
				req_old.RequestDate = travelrequest.RequestDate;
				_context.SaveChanges();
			}
		}
		public void ApproveTravelRequest(int id, string status)
		{
			TravelRequest? tr = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

			if (tr != null)
			{
				tr.ApproveStatus = status;
				if (tr.ApproveStatus == "NotApproved")
				{
					tr.CurrentStatus = "Close";
                    tr.BookingStatus = " - ";
				}
				_context.SaveChanges();
			}
		}

		public void BookTravelRequest(int id, string status)
		{

			TravelRequest? tr = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);
            if (tr != null)
            {
                // Check if the ApprovalStatus is Approved or Pending
                if (tr.ApproveStatus == "Approved" || tr.ApproveStatus == "Pending")
                {
                    tr.BookingStatus = status;
                    tr.CurrentStatus = "Close";
                    _context.SaveChanges(true);
                }
                else
                {
                    // Set BookingStatus to "NotBooked" if ApprovalStatus is not Approved or Pending
                    tr.BookingStatus = "NotBooked";
                    tr.CurrentStatus = "Close";
                    _context.SaveChanges(true);
                }
            }

        }
	}
}
