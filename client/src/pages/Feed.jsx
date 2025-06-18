export default function Feed() {
  const posts = [
    {
      id: 1,
      username: "orkunozdmr",
      userAvatar: "https://i.pravatar.cc/150?img=12",
      image: "https://picsum.photos/600/400?random=1",
      caption: "Bugün hava çok güzel ☀️",
      likes: 120,
    },
    {
      id: 2,
      username: "coder99",
      userAvatar: "https://i.pravatar.cc/150?img=23",
      image: "https://picsum.photos/600/400?random=2",
      caption: "Kodlamak gibisi yok!",
      likes: 89,
    },
  ];

  return (
    <div className="flex flex-col items-center">
      {posts.map((post) => (
        <div
          key={post.id}
          className="w-full max-w-xl bg-white border border-gray-300 rounded-lg shadow p-4 my-4"
        >
          <div className="flex items-center mb-2">
            <img
              src={post.userAvatar}
              alt="avatar"
              className="w-10 h-10 rounded-full mr-3"
            />
            <span className="font-semibold">{post.username}</span>
          </div>
          <img
            src={post.image}
            alt="post"
            className="w-full rounded-md mb-3"
          />
          <div className="flex gap-4 mb-2">
            <button className="text-red-500 hover:text-red-700">
              ❤️ Beğen ({post.likes})
            </button>
            <button className="text-blue-500 hover:text-blue-700">
              💬 Yorum Yap
            </button>
          </div>
          <p>
            <span className="font-semibold">{post.username}</span>{" "}
            {post.caption}
          </p>
        </div>
      ))}
    </div>
  );
}
