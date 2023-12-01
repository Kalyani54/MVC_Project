using MVC_TravelProject.Models;

namespace MVC_TravelProject.Repository
{
    public interface ITravelRepository
    {
        IEnumerable<TravelRequest> GetRequests();

        void RaiseRequest(TravelRequest req);

        void DeleteRequest(int RequestId);

        TravelRequest GetRequestById(int id);

        void UpdateRequest(TravelRequest travelrequest, int id);

        void ApproveTravelRequest(int id, string status);

        void BookTravelRequest(int id, string status);

	}
}
