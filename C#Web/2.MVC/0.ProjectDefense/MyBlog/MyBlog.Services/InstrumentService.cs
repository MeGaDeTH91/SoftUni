namespace MyBlog.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using MyBlog.Common;
    using MyBlog.Common.Helpers;
    using MyBlog.CommonModels.BindingModels.Music.Instruments;
    using MyBlog.CommonModels.ViewModels.Brands;
    using MyBlog.CommonModels.ViewModels.Music.Instruments;
    using MyBlog.Data;
    using MyBlog.Models.Music.Instruments;
    using MyBlog.Services.Interfaces;
    using MyBlog.Models.Users;
    using System;

    public class InstrumentService : BaseBlogService, IInstrumentService
    {
        public InstrumentService(BlogDataDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool AddToFavourites(string userId, int instrumentId)
        {
            var user = this.DbContext
                .Users
                .FirstOrDefault(x => x.Id == userId);

            var instrument = this.DbContext
                .Instruments
                .FirstOrDefault(x => x.Id == instrumentId);

            if (user == null || instrument == null)
            {
                return false;
            }

            var userInstrument = new UserInstruments()
            {
                UserId = userId,
                InstrumentId = instrumentId,
                AddedToFavouritesOn = DateTime.UtcNow
            };

            bool alreadyInFavourites = this.DbContext.FavouriteUserInstruments
                .Any(x => x.UserId == userId && x.InstrumentId == instrumentId);

            if (alreadyInFavourites)
            {
                return false;
            }

            user.FavouriteInstruments.Add(userInstrument);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<int> AddInstrumentAsync(AddInstrumentBindingModel model)
        {
            var checkForDuplicate = this.DbContext
                .Instruments
                .FirstOrDefault(x => x.ModelName == model.ModelName);

            if (checkForDuplicate != null)
            {
                return ErrorId;
            }

            var instrument = this.Mapper.Map<Instrument>(model);

            var instrumentType = this.DbContext
                .InstrumentTypes
                .FirstOrDefault(x => x.Id == model.InstrumentTypeId);

            var brand = this.DbContext
                .Brands
                .FirstOrDefault(x => x.Id == model.BrandId);

            instrument.InstrumentTypeId = instrumentType.Id;
            instrument.InstrumentType = instrumentType;

            instrument.BrandId = brand.Id;
            instrument.Brand = brand;

            if (instrument.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                instrument.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(instrument.HighLightVideoURL);
            }

            await this.DbContext.Instruments.AddAsync(instrument);
            await this.DbContext.SaveChangesAsync();

            return instrument.Id;
        }

        public async Task<int> AddInstrumentTypeAsync(AddInstrumentTypeBindingModel model)
        {
            var existingType = this.DbContext
                .InstrumentTypes
                .FirstOrDefault(x => x.TypeName == model.TypeName);

            if (existingType != null)
            {
                return ErrorId;
            }

            var type = this.Mapper.Map<InstrumentType>(model);

            await this.DbContext.InstrumentTypes.AddAsync(type);
            await this.DbContext.SaveChangesAsync();

            return type.Id;
        }
        
        public async Task<bool> DeleteInstrumentAsync(int id)
        {
            var instrument = this.DbContext
                .Instruments
                .FirstOrDefault(x => x.Id == id);

            if (instrument == null)
            {
                return false;
            }

            this.DbContext.Instruments.Remove(instrument);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> EditInstrumentAsync(EditInstrumentBindingModel model)
        {
            var instrument = this.DbContext
                .Instruments
                .FirstOrDefault(x => x.Id == model.Id);

            if (instrument == null)
            {
                return ErrorId;
            }
            
            instrument.Description = model.Description;
            instrument.PhotoURL = model.PhotoURL;
            instrument.HighLightVideoURL = model.HighLightVideoURL;
            instrument.AdditionalInfoURL = model.AdditionalInfoURL;

            if (instrument.HighLightVideoURL.Contains(CommonConstants.OriginalVideoUrlPart))
            {
                instrument.HighLightVideoURL = ModifyVideoURL_Embeded.ModifyEmbed(instrument.HighLightVideoURL);
            }

            await this.DbContext.SaveChangesAsync();

            return instrument.Id;
        }

        public AddInstrumentBindingModel GetAllBrandsAndInstrumentTypes()
        {
            var brands = this.DbContext
                .Brands
                .Select(this.Mapper.Map<BrandConciseViewModel>)
                .ToList();

            var instrumentTypes = this.DbContext
                .InstrumentTypes
                .Select(this.Mapper.Map<InstrumentTypeViewModel>)
                .ToList();

            var brandsQuery = brands.Select(b => new SelectListItem() { Text = b.BrandName, Value = b.Id.ToString() });
            var instrumentTypesQuery = instrumentTypes.Select(b => new SelectListItem() { Text = b.TypeName, Value = b.Id.ToString() });

            var model = new AddInstrumentBindingModel()
            {
                AllBrands = brandsQuery.ToList(),
                AllInstrumentTypes = instrumentTypesQuery.ToList()
            };

            return model;
        }

        public ICollection<InstrumentConciseViewModel> GetAllInstruments()
        {
            var instruments = this.DbContext
                .Instruments
                .Select(this.Mapper.Map<InstrumentConciseViewModel>)
                .ToList();

            return instruments;
        }

        public InstrumentDetailsViewModel GetInstrument(int id)
        {
            var actualInstrument = this.DbContext
                .Instruments
                .Include(x => x.InstrumentType)
                .Include(x => x.Brand)
                .Include(x => x.AddedToFavoritesBy)
                .FirstOrDefault(x => x.Id == id);

            if (actualInstrument == null)
            {
                return null;
            }

            var instrument = this.Mapper.Map<InstrumentDetailsViewModel>(actualInstrument);

            return instrument;
        }

        public InstrumentTypeViewModel GetInstrumentType(int id)
        {
            var instrumentType = this.DbContext
                .InstrumentTypes
                .Include(x => x.Instruments)
                .FirstOrDefault(x => x.Id == id);

            if (instrumentType == null)
            {
                return null;
            }

            var instrumentTypeModel = new InstrumentTypeViewModel()
            {
                TypeName = instrumentType.TypeName,
                Instruments = this.Mapper.Map<ICollection<InstrumentConciseViewModel>>(instrumentType.Instruments)
            };

            return instrumentTypeModel;
        }
    }
}
