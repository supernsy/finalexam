using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using i_hate_this.Service;
using i_hate_this.Model;


namespace i_hate_this.ViewModel
{
    public partial class MainViewModel:ObservableObject

    {
        /*[ObservableProperty]
        private double _sliderValue;*/ //for slider

        /*[ObservableProperty]
        private string _phoneNumber;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private bool _isTermsAccepted;
        
        

        public bool IsPhoneNumberValid => !string.IsNullOrEmpty(PhoneNumber) && Regex.IsMatch(PhoneNumber, @"^\d+$");

        public bool IsPasswordValid => !string.IsNullOrEmpty(Password) && Password.Length >= 6;

        public bool IsRegisterEnabled => IsPhoneNumberValid && IsPasswordValid && IsTermsAccepted;

        


        [RelayCommand]
        private async Task ToggleTerms()
        {
            IsTermsAccepted = !IsTermsAccepted;
        }*/ //for register

        
        private readonly PostService _postService;

        public MainViewModel()
        {
            _postService = new PostService();
            Posts = new List<Post>();

            
        }

        [ObservableProperty]
        private List<Post> _posts;

        [ObservableProperty]
        private Post _selectedPost;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _body;

        // GET posts
        [RelayCommand]
        public async Task LoadPosts()
        {
            Posts = await _postService.GetPostsAsync();

        }

        [RelayCommand]
        public async Task CreatePost()
        {
            var newPost = new Post
            {
                Title = "New Post Title",  // Replace with user input
                Body = "New Post Content" // Replace with user input
            };
            await _postService.CreatePostAsync(newPost);
            await LoadPosts();
        }

        // Update a Post
        [RelayCommand]
        public async Task UpdatePost()
        {
            if (SelectedPost != null)
            {
                SelectedPost.Title = "Updated Title"; // Replace with user input
                SelectedPost.Body = "Updated Content"; // Replace with user input
                await _postService.UpdatePostAsync(SelectedPost);
                await LoadPosts();
            }
        }

        // DELETE post
        [RelayCommand]
        public async Task DeletePost()
        {
            if (SelectedPost != null)
            {
                // Confirmation dialog logic (Platform-specific UI handling required)
                bool confirm = await App.Current.MainPage.DisplayAlert(
                    "Confirm Delete",
                    $"Are you sure you want to delete the post '{SelectedPost.Title}'?",
                    "Yes",
                    "No"
                );

                if (confirm)
                {
                    await _postService.DeletePostAsync(SelectedPost.Id);
                    Posts.Remove(SelectedPost);
                    await LoadPosts();
                }
            }
        }
    }
}
