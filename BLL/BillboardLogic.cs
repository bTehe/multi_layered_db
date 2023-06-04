using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public class BillboardLogic
    {
        public BillboardController BillboardController;
        
        public BillboardLogic()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingController());
            });

            var mapper = config.CreateMapper();

            var serviceProvider = new ServiceCollection()
               .AddSingleton(mapper)
               .BuildServiceProvider();

            BillboardController = new BillboardController(serviceProvider.GetService<IMapper>());
        }

        public string CreateAd(string user, string category, string tags)
        {
            Billboard billboard = new Billboard();
            billboard.User = user;
            billboard.Category = category;
            billboard.Tags = tags;

            return BillboardController.CreateAd(billboard); 
        }

        public string DeleteAd(int id, string name) { return BillboardController.DeleteAd(id, name); }
        public string[] AllAds() { return BillboardController.AllAds(); }
        public string Deactivate(int id, string name) { return BillboardController.Deactivate(id, name); }
        public string Activate(int id, string name) { return BillboardController.Activate(id, name); }
    }
}
