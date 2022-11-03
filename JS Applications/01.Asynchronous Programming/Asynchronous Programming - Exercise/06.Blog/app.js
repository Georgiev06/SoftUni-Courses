function attachEvents() {
    console.log('TODO...');
    
    const btnLoadPosts = document.getElementById('btnLoadPosts').addEventListener('click', getPosts)
    const btnViewPost = document.getElementById('btnViewPost').addEventListener('click', getComments)
    
    async function getPosts() {
        let postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
        const response = await fetch(postsUrl);
        const data = await response.json();
        
        const posts = document.getElementById('posts');
        posts.innerHTML = '';

        Object.values(data).forEach(post => {
            const option = document.createElement('option');
            option.value = post.id;
            option.textContent = post.title;
            posts.appendChild(option);
        })   
    }

    async function getComments() {
        let postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
        let commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

        const selectedOption = document.getElementById('posts').selectedOptions[0].value;
        const postTitle = document.getElementById('post-title');
        const postBody = document.getElementById('post-body');
        const postComments = document.getElementById('post-comments');

        postComments.innerHTML = '';

        const responsePosts = await fetch(postsUrl);
        const dataPosts = await responsePosts.json();

        const selectedPost = Object.values(dataPosts).find(post => post.id == selectedOption);
        postTitle.textContent = selectedPost.title;
        postBody.textContent = selectedPost.body;

        const responseComments = await fetch(commentsUrl);
        const dataComments = await responseComments.json(); 

        const comments = Object.values(dataComments).filter(comment => comment.postId == selectedOption);

        comments.forEach(comment => {
            const li = document.createElement('li');
            li.textContent = comment.text;
            postComments.appendChild(li);
        })    
    }
}

attachEvents();