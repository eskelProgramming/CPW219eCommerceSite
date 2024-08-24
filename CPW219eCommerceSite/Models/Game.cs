using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPW219eCommerceSite.Models
{
    /// <summary>
    /// Represents a single game available for purchase
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The unique identifier for each game product
        /// </summary>
        [Key]
        public int GameId { get; set; }

        /// <summary>
        /// The official title of the game
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The sales price of the game
        /// </summary>
        [Range(0, 1000)]
        public double Price { get; set; }

        // Todo: Add rating
    }

    /// <summary>
    /// A single video game that has been added to the users
    /// shopping cart cookie
    /// </summary>
    public class CartGameViewModel
    {
        [Key]
        public int GameId { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
    }
}
