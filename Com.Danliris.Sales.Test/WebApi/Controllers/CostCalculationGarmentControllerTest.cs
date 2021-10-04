using AutoMapper;
using Com.Danliris.Sales.Test.WebApi.Utils;
using Com.Danliris.Service.Sales.Lib.AutoMapperProfiles.CostCalculationGarmentProfiles;
using Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.CostCalculationGarmentLogic;
using Com.Danliris.Service.Sales.Lib.Models.CostCalculationGarments;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.Utilities;
using Com.Danliris.Service.Sales.Lib.ViewModels.CostCalculationGarment;
using Com.Danliris.Service.Sales.WebApi.Controllers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Com.Danliris.Sales.Test.WebApi.Controllers
{
    public class CostCalculationGarmentControllerTest : BaseControllerTest<CostCalculationGarmentController, CostCalculationGarment, CostCalculationGarmentViewModel, ICostCalculationGarment>
    {
        [Fact]
        public void Get_PDF_NotFound()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(x => x.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(default(CostCalculationGarment));
            var controller = GetController(mocks);
            var response = controller.GetPDF(1).Result;

            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.NotFound, statusCode);

        }

        [Fact]
        public void Get_PDF_Exception()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(x => x.ReadByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception("error"));
            var controller = GetController(mocks);
            var response = controller.GetPDF(1).Result;

            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);

        }

        [Fact]
        public void Get_PDF_Local_OK()
        {
            var mocks = GetMocks();

            var viewModel = new CostCalculationGarmentViewModel()
            {
                Comodity = new MasterPlanComodityViewModel(),
                Unit = new UnitViewModel(),
                Rate = new RateViewModel { Id = 1, Value = 1 },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                {
                    new CostCalculationGarment_MaterialViewModel()
                    {
                        Category = new CategoryViewModel(),
                        Product = new GarmentProductViewModel(),
                        UOMQuantity = new UOMViewModel(),
                        UOMPrice = new UOMViewModel()
                    }
                },
                UOM = new UOMViewModel(),
                Buyer = new BuyerViewModel(),
                BuyerBrand = new BuyerBrandViewModel(),
                DeliveryDate = DateTimeOffset.UtcNow,
                OTL1 = new RateCalculatedViewModel(),
                OTL2 = new RateCalculatedViewModel(),
                ApprovalMD = new Approval(),
                ApprovalKadivMD = new Approval(),
                IsPosted = true
            };

            mocks.Facade.Setup(x => x.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);

            var controller = GetController(mocks);
            var response = (FileStreamResult)controller.GetPDF(1).Result;

            Assert.Equal("application/pdf", response.ContentType);

        }

        [Fact]
        public void Get_PDF_Draft_OK()
        {
            var mocks = GetMocks();

            var viewModel = new CostCalculationGarmentViewModel()
            {
                Comodity = new MasterPlanComodityViewModel(),
                Unit = new UnitViewModel(),
                Rate = new RateViewModel(),
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                {
                    new CostCalculationGarment_MaterialViewModel()
                    {
                        Category = new CategoryViewModel(),
                        Product = new GarmentProductViewModel(),
                        UOMQuantity = new UOMViewModel(),
                        UOMPrice = new UOMViewModel()
                    }
                },
                UOM = new UOMViewModel(),
                Buyer = new BuyerViewModel(),
                BuyerBrand = new BuyerBrandViewModel(),
                DeliveryDate = DateTimeOffset.UtcNow,
                OTL1 = new RateCalculatedViewModel(),
                OTL2 = new RateCalculatedViewModel(),
                ApprovalMD = new Approval(),
                ApprovalKadivMD = new Approval()
            };

            mocks.Facade.Setup(x => x.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);

            var controller = GetController(mocks);
            var response = (FileStreamResult)controller.GetPDF(1).Result;

            Assert.Equal("application/pdf", response.ContentType);

        }

        [Fact]
        public async Task GetById_RO_Garment_Validation_NotNullModel_ReturnOK()
        {
            var ViewModel = this.ViewModel;
            ViewModel.CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>();

            var mocks = GetMocks();
            mocks.Facade
                .Setup(f => f.ReadByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Model);
            mocks.Facade
                .Setup(f => f.GetProductNames(It.IsAny<List<long>>()))
                .ReturnsAsync(new Dictionary<long, string>());
            mocks.Mapper
                .Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>()))
                .Returns(ViewModel);

            var controller = GetController(mocks);
            var response = await controller.GetById_RO_Garment_Validation(It.IsAny<int>());

            Assert.Equal((int)HttpStatusCode.OK, GetStatusCode(response));
        }

        [Fact]
        public async Task GetById_RO_Garment_Validation_NullModel_ReturnNotFound()
        {
            var mocks = GetMocks();
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(ViewModel);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync((CostCalculationGarment)null);

            var controller = GetController(mocks);
            var response = await controller.GetById_RO_Garment_Validation(It.IsAny<int>());

            Assert.Equal((int)HttpStatusCode.NotFound, GetStatusCode(response));
        }

        [Fact]
        public async Task GetById_RO_Garment_Validation_ThrowException_ReturnInternalServerError()
        {
            var mocks = this.GetMocks();
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception());

            var controller = GetController(mocks);
            var response = await controller.GetById_RO_Garment_Validation(It.IsAny<int>());

            Assert.Equal((int)HttpStatusCode.InternalServerError, GetStatusCode(response));
        }

        [Fact]
        public async Task GetById_RO_Garment_Validation_Return_BadRequest()
        {
            var mocks = this.GetMocks();
           
            var controller = GetController(mocks);
            controller.ModelState.AddModelError("key", "value");
            var response = await controller.GetById_RO_Garment_Validation(It.IsAny<int>());

            Assert.Equal((int)HttpStatusCode.BadRequest, GetStatusCode(response));
        }

        [Fact]
        public void Validate_ViewModel()
        {
            List<CostCalculationGarmentViewModel> viewModels = new List<CostCalculationGarmentViewModel>
            {
                new CostCalculationGarmentViewModel()
                {
                    FabricAllowance = -1,
                    AccessoriesAllowance = -1,
                    ApprovalMD = new Approval(),
                    ApprovalPurchasing = new Approval(),
                    ApprovalIE = new Approval(),
                    ApprovalPPIC = new Approval(),
                    ApprovalKadivMD = new Approval(),
                },
                new CostCalculationGarmentViewModel()
                {
                    Quantity = 0,
                    DeliveryDate = DateTimeOffset.Now.AddDays(-1),
                    SMV_Cutting = 0,
                    SMV_Sewing = 0,
                    SMV_Finishing = 0,
                    ConfirmPrice = 0,
                    CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>
                    {
                        new CostCalculationGarment_MaterialViewModel(),
                        new CostCalculationGarment_MaterialViewModel
                        {
                            Category = new CategoryViewModel { code = "CategoryCode" }
                        },
                        new CostCalculationGarment_MaterialViewModel
                        {
                            Category = new CategoryViewModel { code = "CategoryCode" },
                            Quantity = 0,
                            Conversion = 0
                        },
                        new CostCalculationGarment_MaterialViewModel
                        {
                            PRMasterItemId = 1,
                            Category = new CategoryViewModel { code = "CategoryCode" },
                            Quantity = 2,
                            Conversion = 1,
                            BudgetQuantity = 2,
                            AvailableQuantity = 1
                        },
                        new CostCalculationGarment_MaterialViewModel
                        {
                            Category = new CategoryViewModel { code = "CategoryCode" },
                            UOMPrice = new UOMViewModel() { Unit = "Unit" },
                            UOMQuantity = new UOMViewModel() { Unit = "Unit" },
                            Conversion = 2
                        }
                    }
                }
            };

            foreach (var viewModel in viewModels)
            {
                var defaultValidationResult = viewModel.Validate(null);
                Assert.True(defaultValidationResult.Count() > 0);
            }
        }

        private async Task<int> GetStatusCodePatch((Mock<IIdentityService> IdentityService, Mock<IValidateService> ValidateService, Mock<ICostCalculationGarment> Facade, Mock<IMapper> Mapper, Mock<IServiceProvider> ServiceProvider) mocks, int id)
        {
            CostCalculationGarmentController controller = GetController(mocks);

            JsonPatchDocument<CostCalculationGarment> patch = new JsonPatchDocument<CostCalculationGarment>();
            IActionResult response = await controller.Patch(id, patch);

            return this.GetStatusCode(response);
        }

        [Fact]
        public async Task Patch_InvalidId_ReturnNotFound()
        {
            int statusCode = await this.GetStatusCodePatch(GetMocks(), 1);
            Assert.Equal((int)HttpStatusCode.NotFound, statusCode);
        }

        [Fact]
        public async Task Patch_ValidId_ReturnNoContent()
        {
            var mocks = GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.Patch(It.IsAny<long>(), It.IsAny<JsonPatchDocument<CostCalculationGarment>>())).ReturnsAsync(1);

            int statusCode = await this.GetStatusCodePatch(mocks, 1);
            Assert.Equal((int)HttpStatusCode.NoContent, statusCode);
        }

        [Fact]
        public async Task Patch_ThrowException_ReturnInternalServerError()
        {
            var mocks = GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.Patch(It.IsAny<long>(), It.IsAny<JsonPatchDocument<CostCalculationGarment>>())).ThrowsAsync(new Exception());

            int statusCode = await this.GetStatusCodePatch(mocks, 1);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        [Fact]
        public async Task Update_Ro_Sample()
        {
            var mocks = this.GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ReturnsAsync(1);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);

            var controller = GetController(mocks);
            var response = await controller.PutRoSample(id, It.IsAny<CostCalculationGarmentViewModel>());

            Assert.Equal((int)HttpStatusCode.NoContent, GetStatusCode(response));
        }

        [Fact]
        public async Task Update_Ro_Sample_NotFound()
        {
            var mocks = this.GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ReturnsAsync(1);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(default(CostCalculationGarment));

            var controller = GetController(mocks);
            var response = await controller.PutRoSample(id, It.IsAny<CostCalculationGarmentViewModel>());

            Assert.Equal((int)HttpStatusCode.NotFound, GetStatusCode(response));
        }

        [Fact]
        public async Task Update_Ro_Sample_ThrowException()
        {
            var mocks = this.GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ThrowsAsync(new Exception());

            var controller = GetController(mocks);
            var response = await controller.PutRoSample(id, It.IsAny<CostCalculationGarmentViewModel>());

            Assert.Equal((int)HttpStatusCode.InternalServerError, GetStatusCode(response));
        }

        private int GetStatusCodeGet((Mock<IIdentityService> IdentityService, Mock<IValidateService> ValidateService, Mock<ICostCalculationGarment> Facade, Mock<IMapper> Mapper, Mock<IServiceProvider> ServiceProvider) mocks)
        {
            CostCalculationGarmentController controller = this.GetController(mocks);
            IActionResult response = controller.GetForROAcceptance();

            return this.GetStatusCode(response);
        }

        [Fact]
        public void Get_ForROAcceptance_WithoutException_ReturnOK()
        {
            var mocks = this.GetMocks();
            mocks.Facade.Setup(f => f.ReadForROAcceptance(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ReadResponse<CostCalculationGarment>(new List<CostCalculationGarment>(), 0, new Dictionary<string, string>(), new List<string>()));
            mocks.Mapper.Setup(f => f.Map<List<CostCalculationGarmentViewModel>>(It.IsAny<List<CostCalculationGarment>>())).Returns(this.ViewModels);

            int statusCode = this.GetStatusCodeGet(mocks);
            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void Get_ForROAcceptance_ReadThrowException_ReturnInternalServerError()
        {
            var mocks = this.GetMocks();
            mocks.Facade.Setup(f => f.ReadForROAcceptance(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());

            int statusCode = this.GetStatusCodeGet(mocks);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        private async Task<int> GetAcceptCC((Mock<IIdentityService> IdentityService, Mock<IValidateService> ValidateService, Mock<ICostCalculationGarment> Facade, Mock<IMapper> Mapper, Mock<IServiceProvider> ServiceProvider) mocks, int id)
        {
            CostCalculationGarmentController controller = GetController(mocks);
            List<long> Id = new List<long> { 1 };
            IActionResult response = await controller.AcceptCC(Id);

            return this.GetStatusCode(response);
        }

        [Fact]
        public async Task Should_Success_AcceptCC()
        {
            var mocks = GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ReturnsAsync(1);

            List<long> listId = new List<long> { viewModel.Id };

            var controller = GetController(mocks);
            var response = await controller.AcceptCC(listId);
            Assert.Equal((int)HttpStatusCode.OK, GetStatusCode(response));
        }

        [Fact]
        public async Task Should_Fail_AcceptCC()
        {
            var mocks = GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ReturnsAsync(1);
            mocks.Facade.Setup(f => f.AcceptanceCC(It.IsAny<List<long>>(), It.IsAny<string>()))
                .Throws(new Exception());
            List<long> listId = new List<long> { viewModel.Id };

            var controller = GetController(mocks);
            var response = await controller.AcceptCC(listId);
            Assert.Equal((int)HttpStatusCode.InternalServerError, GetStatusCode(response));
        }

        private int GetStatusCodeGetAvailable((Mock<IIdentityService> IdentityService, Mock<IValidateService> ValidateService, Mock<ICostCalculationGarment> Facade, Mock<IMapper> Mapper, Mock<IServiceProvider> ServiceProvider) mocks)
        {
            CostCalculationGarmentController controller = this.GetController(mocks);
            IActionResult response = controller.GetForROAvailable();

            return this.GetStatusCode(response);
        }

        [Fact]
        public void Get_ForROAvailable_WithoutException_ReturnOK()
        {
            var mocks = this.GetMocks();
            mocks.Facade.Setup(f => f.ReadForROAvailable(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ReadResponse<CostCalculationGarment>(new List<CostCalculationGarment>(), 0, new Dictionary<string, string>(), new List<string>()));
            mocks.Mapper.Setup(f => f.Map<List<CostCalculationGarmentViewModel>>(It.IsAny<List<CostCalculationGarment>>())).Returns(this.ViewModels);

            int statusCode = this.GetStatusCodeGetAvailable(mocks);
            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void Get_ForROAvailable_ReadThrowException_ReturnInternalServerError()
        {
            var mocks = this.GetMocks();
            mocks.Facade.Setup(f => f.ReadForROAvailable(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());

            int statusCode = this.GetStatusCodeGetAvailable(mocks);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        private async Task<int> GetAvailableCC((Mock<IIdentityService> IdentityService, Mock<IValidateService> ValidateService, Mock<ICostCalculationGarment> Facade, Mock<IMapper> Mapper, Mock<IServiceProvider> ServiceProvider) mocks, int id)
        {
            CostCalculationGarmentController controller = GetController(mocks);
            List<long> Id = new List<long> { 1 };
            IActionResult response = await controller.AvailableCC(Id);

            return this.GetStatusCode(response);
        }

        [Fact]
        public async Task Should_Success_AvailableCC()
        {
            var mocks = GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ReturnsAsync(1);

            List<long> listId = new List<long> { viewModel.Id };

            var controller = GetController(mocks);
            var response = await controller.AvailableCC(listId);
            Assert.Equal((int)HttpStatusCode.OK, GetStatusCode(response));
        }


        [Fact]
        public async Task Should_Fail_AvailableCC()
        {
            var mocks = GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ReturnsAsync(1);
            mocks.Facade.Setup(f => f.AvailableCC(It.IsAny<List<long>>(), It.IsAny<string>()))
                .Throws(new Exception());

            List<long> listId = new List<long> { viewModel.Id };

            var controller = GetController(mocks);
            var response = await controller.AvailableCC(listId);
            Assert.Equal((int)HttpStatusCode.InternalServerError, GetStatusCode(response));
        }

        private int GetStatusCodeGetDistribute((Mock<IIdentityService> IdentityService, Mock<IValidateService> ValidateService, Mock<ICostCalculationGarment> Facade, Mock<IMapper> Mapper, Mock<IServiceProvider> ServiceProvider) mocks)
        {
            CostCalculationGarmentController controller = this.GetController(mocks);
            IActionResult response = controller.GetForRODistribute();

            return this.GetStatusCode(response);
        }

        [Fact]
        public void Get_ForRODistribute_WithoutException_ReturnOK()
        {
            var mocks = this.GetMocks();
            mocks.Facade.Setup(f => f.ReadForRODistribution(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ReadResponse<CostCalculationGarment>(new List<CostCalculationGarment>(), 0, new Dictionary<string, string>(), new List<string>()));
            mocks.Mapper.Setup(f => f.Map<List<CostCalculationGarmentViewModel>>(It.IsAny<List<CostCalculationGarment>>())).Returns(this.ViewModels);

            int statusCode = this.GetStatusCodeGetDistribute(mocks);
            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void Get_ForRODistribute_ReadThrowException_ReturnInternalServerError()
        {
            var mocks = this.GetMocks();
            mocks.Facade.Setup(f => f.ReadForRODistribution(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());

            int statusCode = this.GetStatusCodeGetDistribute(mocks);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        private async Task<int> GetDistributeCC((Mock<IIdentityService> IdentityService, Mock<IValidateService> ValidateService, Mock<ICostCalculationGarment> Facade, Mock<IMapper> Mapper, Mock<IServiceProvider> ServiceProvider) mocks, int id)
        {
            CostCalculationGarmentController controller = GetController(mocks);
            List<long> Id = new List<long> { 1 };
            IActionResult response = await controller.DistributeCC(Id);

            return this.GetStatusCode(response);
        }

        [Fact]
        public async Task Should_Success_DistributeCC()
        {
            var mocks = GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ReturnsAsync(1);

            List<long> listId = new List<long> { viewModel.Id };

            var controller = GetController(mocks);
            var response = await controller.DistributeCC(listId);
            Assert.Equal((int)HttpStatusCode.OK, GetStatusCode(response));
        }

        [Fact]
        public async Task Should_Fail_DistributeCC()
        {
            var mocks = GetMocks();
            mocks.ValidateService.Setup(vs => vs.Validate(It.IsAny<CostCalculationGarmentViewModel>())).Verifiable();
            var id = 1;
            var viewModel = new CostCalculationGarmentViewModel()
            {
                Id = id
            };
            mocks.Mapper.Setup(m => m.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);
            mocks.Facade.Setup(f => f.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Facade.Setup(f => f.UpdateAsync(It.IsAny<int>(), It.IsAny<CostCalculationGarment>())).ReturnsAsync(1);
            mocks.Facade.Setup(f => f.DistributeCC(It.IsAny<List<long>>(), It.IsAny<string>()))
                .Throws(new Exception());

            List<long> listId = new List<long> { viewModel.Id };

            var controller = GetController(mocks);
            var response = await controller.DistributeCC(listId);
            Assert.Equal((int)HttpStatusCode.InternalServerError, GetStatusCode(response));
        }

        [Fact]
        public async Task PostCC_Success_ReturnNoContent()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.PostCC(It.IsAny<List<long>>())).ReturnsAsync(1);

            var controller = GetController(mocks);
            var response = await controller.PostCC(It.IsAny<List<long>>());

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.NoContent, statusCode);
        }

        [Fact]
        public async Task PostCC_NoChanges_ReturnInternalServerError()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.PostCC(It.IsAny<List<long>>())).ReturnsAsync(0);

            var controller = GetController(mocks);
            var response = await controller.PostCC(It.IsAny<List<long>>());

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        [Fact]
        public async Task PostCC_Failed_ReturnInternalServerError()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.PostCC(It.IsAny<List<long>>())).ThrowsAsync(new Exception(string.Empty));

            var controller = GetController(mocks);
            var response = await controller.PostCC(It.IsAny<List<long>>());

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        [Fact]
        public async Task UnpostCC_Success_ReturnNoContent()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.UnpostCC(It.IsAny<long>(), It.IsAny<string>())).ReturnsAsync(1);

            var controller = GetController(mocks);
            var response = await controller.UnpostCC(It.IsAny<long>(), "Reason");

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.NoContent, statusCode);
        }

        [Fact]
        public async Task UnpostCC_Invalid_ReturnBadRequest()
        {
            var mocks = GetMocks();

            var controller = GetController(mocks);
            var response = await controller.UnpostCC(It.IsAny<long>(), null);

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.BadRequest, statusCode);
        }

        [Fact]
        public async Task UnpostCC_Failed_ReturnInternalServerError()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.UnpostCC(It.IsAny<long>(), It.IsAny<string>())).ThrowsAsync(new Exception(string.Empty));

            var controller = GetController(mocks);
            var response = await controller.UnpostCC(It.IsAny<long>(), "Reason");

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        [Fact]
        public void Read_Unpost_Reason_Return_OK()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.ReadUnpostReasonCreators(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<string>());

            var controller = GetController(mocks);
            var response = controller.ReadUnpostReasonCreators(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>());

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void Read_Unpost_Reason_Return_InternalServerError()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.ReadUnpostReasonCreators(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new Exception(string.Empty));

            var controller = GetController(mocks);
            var response = controller.ReadUnpostReasonCreators(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>());

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        //[Fact]
        public void Get_Budget_OK()
        {
            var mocks = GetMocks();

            var viewModel = new CostCalculationGarmentViewModel()
            {
                Comodity = new MasterPlanComodityViewModel(),
                Unit = new UnitViewModel(),
                Rate = new RateViewModel()
                {
                    Value = 1
                },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                {
                    new CostCalculationGarment_MaterialViewModel()
                    {
                        Category = new CategoryViewModel(),
                        Product = new GarmentProductViewModel(),
                        UOMQuantity = new UOMViewModel(),
                        UOMPrice = new UOMViewModel()
                    }
                },
                UOM = new UOMViewModel(),
                Buyer = new BuyerViewModel(),
                BuyerBrand = new BuyerBrandViewModel(),
                DeliveryDate = DateTimeOffset.UtcNow,
                OTL1 = new RateCalculatedViewModel(),
                OTL2 = new RateCalculatedViewModel(),
                ConfirmPrice = 1,
                ConfirmDate = DateTimeOffset.UtcNow,
                ApprovalMD = new Approval(),
                ApprovalPurchasing = new Approval(),
                ApprovalKadivMD = new Approval(),
                IsPosted = true
            };

            mocks.Facade.Setup(x => x.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);

            var controller = GetController(mocks);
            var response = (FileStreamResult)controller.GetBudget(1).Result;

            Assert.Equal("application/pdf", response.ContentType);
        }

        //[Fact]
        public void Get_Budget_Draft_OK()
        {
            var mocks = GetMocks();

            var viewModel = new CostCalculationGarmentViewModel()
            {
                Comodity = new MasterPlanComodityViewModel(),
                Unit = new UnitViewModel(),
                Rate = new RateViewModel()
                {
                    Value = 1
                },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                {
                    new CostCalculationGarment_MaterialViewModel()
                    {
                        Category = new CategoryViewModel(),
                        Product = new GarmentProductViewModel(),
                        UOMQuantity = new UOMViewModel(),
                        UOMPrice = new UOMViewModel()
                    }
                },
                UOM = new UOMViewModel(),
                Buyer = new BuyerViewModel(),
                BuyerBrand = new BuyerBrandViewModel(),
                DeliveryDate = DateTimeOffset.UtcNow,
                OTL1 = new RateCalculatedViewModel(),
                OTL2 = new RateCalculatedViewModel(),
                ConfirmPrice = 1,
                ConfirmDate = DateTimeOffset.UtcNow,
                ApprovalMD = new Approval(),
                ApprovalPurchasing = new Approval(),
                ApprovalKadivMD = new Approval()
            };

            mocks.Facade.Setup(x => x.ReadByIdAsync(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);

            var controller = GetController(mocks);
            var response = (FileStreamResult)controller.GetBudget(1).Result;

            Assert.Equal("application/pdf", response.ContentType);
        }

        [Fact]
        public void Get_Budget_InternalServerError()
        {
            var mocks = GetMocks();

            var viewModel = new CostCalculationGarmentViewModel()
            {
                Comodity = new MasterPlanComodityViewModel(),
                Unit = new UnitViewModel(),
                Rate = new RateViewModel()
                {
                    Value = 1
                },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                {
                    new CostCalculationGarment_MaterialViewModel()
                    {
                        Category = new CategoryViewModel(),
                        Product = new GarmentProductViewModel(),
                        UOMQuantity = new UOMViewModel(),
                        UOMPrice = new UOMViewModel()
                    }
                },
                UOM = new UOMViewModel(),
                Buyer = new BuyerViewModel(),
                BuyerBrand = new BuyerBrandViewModel(),
                DeliveryDate = DateTimeOffset.UtcNow,
                OTL1 = new RateCalculatedViewModel(),
                OTL2 = new RateCalculatedViewModel(),
                ConfirmPrice = 1,
                ConfirmDate = DateTimeOffset.UtcNow
            };

            mocks.Facade.Setup(x => x.ReadByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception());
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);

            var controller = GetController(mocks);
            var response = controller.GetBudget(1).Result;

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);

        }

        [Fact]
        public void Mapping_With_AutoMapper_Profiles()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<CostCalculationGarmentMapper>();
                cfg.AddProfile<CostCalculationGarmentMaterialMapper>();
            });
            var mapper = configuration.CreateMapper();

            CostCalculationGarmentViewModel costCalculationGarmentViewModel = new CostCalculationGarmentViewModel { Id = 1 };
            CostCalculationGarment costCalculationGarment = mapper.Map<CostCalculationGarment>(costCalculationGarmentViewModel);

            Assert.Equal(costCalculationGarmentViewModel.Id, costCalculationGarment.Id);

            CostCalculationGarment_MaterialViewModel costCalculationGarment_MaterialViewModel = new CostCalculationGarment_MaterialViewModel { Id = 1 };
            CostCalculationGarment_Material costCalculationGarment_Material = mapper.Map<CostCalculationGarment_Material>(costCalculationGarment_MaterialViewModel);

            Assert.Equal(costCalculationGarment_MaterialViewModel.Id, costCalculationGarment_Material.Id);
        }

		[Fact]
		public void GetComodityQtyOrderHoursBuyerByRo_Return_OK()
		{
			var mocks = GetMocks();
			mocks.Facade.Setup(f => f.GetComodityQtyOrderHoursBuyerByRo(It.IsAny<string>()))
				.Returns(new List<CostCalculationGarmentDataProductionReport>());

			var controller = GetController(mocks);
			var response = controller.GetComodityQtyOrderHoursBuyerByRo(It.IsAny<string>());

			var statusCode = GetStatusCode(response);
			Assert.Equal((int)HttpStatusCode.OK, statusCode);
		}


		[Fact]
		public void GetComodityQtyOrderHoursBuyerByRo_Return_InternalServerError()
		{
			var mocks = GetMocks();
			mocks.Facade.Setup(f => f.GetComodityQtyOrderHoursBuyerByRo(It.IsAny<string>()))
				.Throws(new Exception(string.Empty));

			var controller = GetController(mocks);
			var response = controller.GetComodityQtyOrderHoursBuyerByRo(It.IsAny<string>());

			var statusCode = GetStatusCode(response);
			Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
		}

        [Fact]
        public void Get_Dynamic_WithoutException_ReturnOK()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.ReadDynamic(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ReadResponse<dynamic>(new List<dynamic>(), 0, new Dictionary<string, string>(), new List<string>()));

            CostCalculationGarmentController controller = GetController(mocks);
            IActionResult response = controller.GetDynamic();
            
            int statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void Get_Dynamic_ReadThrowException_ReturnInternalServerError()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.ReadDynamic(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());

            CostCalculationGarmentController controller = GetController(mocks);
            IActionResult response = controller.GetDynamic();

            int statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        [Fact]
        public void Get_Materials_WithoutException_ReturnOK()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.ReadMaterials(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ReadResponse<dynamic>(new List<dynamic>(), 0, new Dictionary<string, string>(), new List<string>()));

            CostCalculationGarmentController controller = GetController(mocks);
            IActionResult response = controller.GetMaterials();
            
            int statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void Get_Materials_ReadThrowException_ReturnInternalServerError()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.ReadMaterials(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());

            CostCalculationGarmentController controller = GetController(mocks);
            IActionResult response = controller.GetMaterials();

            int statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        [Fact]
        public void Get_MaterialsByPRMasterItemIds_WithoutException_ReturnOK()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.ReadMaterialsByPRMasterItemIds(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ReadResponse<dynamic>(new List<dynamic>(), 0, new Dictionary<string, string>(), new List<string>()));

            CostCalculationGarmentController controller = GetController(mocks);
            IActionResult response = controller.GetMaterialsByPRMasterItemIds();
            
            int statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void Get_MaterialsByPRMasterItemIds_ReadThrowException_ReturnInternalServerError()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(f => f.ReadMaterialsByPRMasterItemIds(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());

            CostCalculationGarmentController controller = GetController(mocks);
            IActionResult response = controller.GetMaterialsByPRMasterItemIds();

            int statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }
    }
}
