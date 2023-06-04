using System;
using System.Linq;
using AutoMapper;
using DAL;

namespace BLL
{
    public class BillboardController
    {
        UnitOfWork unitOfWork;
        readonly IMapper _mapper;
        public BillboardController(IMapper mapper) { unitOfWork = new UnitOfWork(); _mapper = mapper; }

        public string CreateAd(Billboard blbrd)
        {
            Billboard billboard = blbrd;
            
            var dbBillboard = _mapper.Map<DBBillboard>(billboard);
            unitOfWork.Billboards.Create(dbBillboard);
            unitOfWork.Save();

            return $"User: {billboard.User}\n Category: {billboard.Category}\n Tags:{billboard.Tags}";
        }

        public string DeleteAd(int id, string name)
        {
            if (unitOfWork.Billboards.Get(id) == null) return "This ad doesn't exist";

            if (name == unitOfWork.Billboards.Get(id).User)
            {
                unitOfWork.Billboards.Delete(id);
                unitOfWork.Save();
                return $"The ad with ID {id} was deleted!";
            }
            else
                return "You don't have an access to deleting this ad";
        }

        public string[] AllAds()
        {
            int size = unitOfWork.Billboards.GetAll().Count();
            if (size == 0) return new string[] {"There are no any adverts on the billboard!"};

            string[] arr = new string[size];
            DBBillboard[] allAds = unitOfWork.Billboards.GetAll().ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                DBBillboard item = allAds[i];

                if (item.IsActive)
                    arr[i] = $"User: {item.User}\n Category: {item.Category}\n Tags:{item.Tags}\n Active:{item.IsActive}\n"; 
            }

            return arr;
        }

        public string Deactivate(int id, string name)
        {
            try
            {
                if (unitOfWork.Billboards.Get(id) == null) return "This ad doesn't exist";

                bool isExist = name == unitOfWork.Billboards.Get(id).User;
                if (isExist)
                {
                    unitOfWork.Billboards.Get(id).IsActive = false;
                    unitOfWork.Save();
                    return $"The advertisement with ID {id} was deactivated!";
                }
                else
                    return "You don't have permission to deactivate this ad!";
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }

        public string Activate(int id, string name)
        {
            try
            {
                if (unitOfWork.Billboards.Get(id) == null) return "This ad doesn't exist";
                bool isExist = name == unitOfWork.Billboards.Get(id).User;

                if (isExist)
                {
                    unitOfWork.Billboards.Get(id).IsActive = true;
                    unitOfWork.Save();
                    return $"The advertisement with ID {id} was activated!";
                }
                else
                    return $"You don't have permission to activate this ad!";
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
