
namespace ShopOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController: ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
		[HttpGet]
		public async Task<ActionResult<ProductDto>> GetProducts()
		{
			try
			{
				var products = await productRepository.GetProducts();
				if (products == null)
				{
					return NotFound();
				}
				var dtos = mapper.Map<IEnumerable<ProductDto>>(products);
				return Ok(dtos);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                var product = await productRepository.GetProductById(id);
                if (product == null)
                {
                    return BadRequest();
                }
                var dto = mapper.Map<ProductDto>(product);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

	}
}
