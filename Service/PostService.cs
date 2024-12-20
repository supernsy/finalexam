using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using i_hate_this.Model;
using Newtonsoft.Json;

namespace i_hate_this.Service
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/posts")
            };
        }

        // GET: Fetch all posts
        public async Task<List<Post>> GetPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Post>>("") ?? new List<Post>();
        }

        // POST: Create a new post
        public async Task CreatePostAsync(Post post)
        {
            await _httpClient.PostAsJsonAsync("", post);
        }

        // PUT: Update an existing post
        public async Task UpdatePostAsync(Post post)
        {
            await _httpClient.PutAsJsonAsync($"/{post.Id}", post);
        }

        // DELETE: Delete a post
        public async Task DeletePostAsync(int postId)
        {
            await _httpClient.DeleteAsync($"/{postId}");
        }
    }
}
