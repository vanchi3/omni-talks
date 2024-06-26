﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class Post
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string Content { get; set; } = null!;
		[Required]
		public DateTime CreatedDate { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }

		public User User { get; set; } = null!;

		public List<PostLike> PostLikes { get; set; } = [];

		public List<Comment> Comments { get; set; } = [];

		[ForeignKey(nameof(Category))]
		public Guid CategoryId { get; set; }
		public Category Category { get; set; } = null!;

		public string? ImgUrl { get; set; } = null!;
	}
}
