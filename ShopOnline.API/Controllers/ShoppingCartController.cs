using ShopOnline.API.Respositores;

namespace ShopOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository cartRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;


        public ShoppingCartController(IShoppingCartRepository cartRepository,
                IProductRepository productRepository,
                IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetAll(int userId)
        {
            try
            {
                var cartItems = await cartRepository.GetAll(userId);

                if (cartItems == null )
                {
                    return NoContent();
                }
                
                var dtos = mapper.Map<IEnumerable<CartItemDto>>(cartItems);
                return Ok(dtos);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{cartItemId:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int cartItemId)
        {
            try
            {
                var cartItem = await cartRepository.GetItem(cartItemId);

                if (cartItem == null)
                {
                    return NotFound();
                }
                var dto = mapper.Map<CartItemDto>(cartItem);
                return Ok(dto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> AddItem([FromBody] CartItemToAddDto cartItemToAdd)
        {
            try
            {
                var cartItem = await cartRepository.AddItem(cartItemToAdd);
                
                if (cartItem == null)
                {
                    return NoContent();
                }

                var dto = mapper.Map<CartItemDto>(cartItem);
                return CreatedAtAction(nameof(GetItem), new { cartItemId = cartItem.Id }, cartItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{cartItemId:int}")]
        public async Task<ActionResult<CartItemDto>> RemoveItem(int cartItemId)
        {
            try
            {
                var cartItem = await cartRepository.RemoveItem(cartItemId);
                if (cartItem == null)
                {
                    return NotFound();                    
                }
                var dto = mapper.Map<CartItemDto>(cartItem);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{cartItemId:int}")]
        public async Task<ActionResult<CartItemDto>> UpdateItem(int cartItemId, CartItemToUpdateDto cartItemToUpdate)
        {
            try
            {
                var cartItem = await cartRepository.UpdateItem(cartItemId, cartItemToUpdate);
                if (cartItem is null)
                {
                    return NotFound();
                }
                var dto = mapper.Map<CartItemDto>(cartItem);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
