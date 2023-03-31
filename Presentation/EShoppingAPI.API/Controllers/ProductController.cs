using EShoppingAPI.Application.Abstraction.Storage;
using EShoppingAPI.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage;
using EShoppingAPI.Application.Features.Commants.Product.CreateProduct;
using EShoppingAPI.Application.Features.Commants.Product.RemoveProduct;
using EShoppingAPI.Application.Features.Commants.Product.UpdateProduct;
using EShoppingAPI.Application.Features.Commants.ProductImageFile.RemoveProductImageFile;
using EShoppingAPI.Application.Features.Commants.ProductImageFile.UpdateProductImageFile;
using EShoppingAPI.Application.Features.Queries.Product.GetAllProduct;
using EShoppingAPI.Application.Features.Queries.Product.GetByIdProduct;
using EShoppingAPI.Application.Features.Queries.ProductImageFile;
using EShoppingAPI.Application.Repositories;
using EShoppingAPI.Application.RequestParameters;
using EShoppingAPI.Application.ViewModles.Product;
using EShoppingAPI.Domain.Entities;
using EShoppingAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EShoppingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;

        readonly IProductImageReadRepository _productImageReadRepository;
        readonly IProductImageWriteRepository _productImageWriteRepository;

        readonly IFileReadRepository _fileReadRepository;
        readonly IFileWriteRepository _fileWriteRepository;

        readonly IStorageServic _storageServic;


        readonly IMediator _mediator;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IWebHostEnvironment webHostEnvironment, IInvoiceFileReadRepository invoiceFileReadRepository, IInvoiceFileWriteRepository invoiceFileWriteRepository, IProductImageReadRepository productImageReadRepository, IProductImageWriteRepository productImageWriteRepository, IFileReadRepository fileReadRepository, IFileWriteRepository fileWriteRepository, IStorageServic storageServic, IMediator mediator)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _webHostEnvironment = webHostEnvironment;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _productImageReadRepository = productImageReadRepository;
            _productImageWriteRepository = productImageWriteRepository;
            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
            _storageServic = storageServic;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse getAllProductQueryResponse  = await _mediator.Send(getAllProductQueryRequest);
            return Ok(getAllProductQueryResponse);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromHeader] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryRespons getByIdProductQueryRespons = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(getByIdProductQueryRespons);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Post(CreateProductCommantRequest createProductCommantRequest)
        {
            CreateProductCommantRespons respons = await _mediator.Send(createProductCommantRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Put([FromBody]UpdateProductCommentRequest updateProductCommentRequest)
        {
            UpdateProductCommentRespons respons = await _mediator.Send(updateProductCommentRequest);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Delete([FromHeader]RemoveProductCommentRequest removeProductCommentRequest) 
        {
            RemoveProductCommentRespons respons = await _mediator.Send(removeProductCommentRequest);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Upload([FromQuery]UpdateProductImageFileCommentRequest updateProductImageFileCommentRequest)
        {
            updateProductImageFileCommentRequest.Files = Request.Form.Files;
            UpdateProductImageFileCommentRespons respons = await _mediator.Send(updateProductImageFileCommentRequest);
            return Ok();
        }
        [HttpGet("[action]/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetProductImage([FromRoute]GetProductImageFileQueryRequest getProductImageFileQueryRequest)
        {
            List<GetProductImageFileQueryRespons> respons = await _mediator.Send(getProductImageFileQueryRequest);
            return Ok(respons);
        }
        [HttpDelete("[action]/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteProductImage([FromRoute]RemoveProductImageFileCommentRequest removeProductImageFileCommentRequest, [FromQuery] string imageId)
        {
            removeProductImageFileCommentRequest.imageId = imageId;
            RemoveProductImageFileCommentRespons respons = await _mediator.Send(removeProductImageFileCommentRequest);
            return Ok();
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery]ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        {
          ChangeShowcaseImageCommandRespons respons = await _mediator.Send(changeShowcaseImageCommandRequest);
            return Ok(respons);
        }
    }
}
