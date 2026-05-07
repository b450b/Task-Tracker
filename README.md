# 🚀 My Simple Task Tracker (CLI)

### 📝 Note from the Author
Hi! I'm a first-year university student at the Faculty of Mechanics and Mathematics (**Mekhmat**). This is one of my very first working projects, built as part of the [roadmap.sh](https://roadmap.sh/projects/task-tracker) challenges.

Even though I briefly studied C# in high school, building a tool that handles real-time data and file systems was a great learning experience. It’s not a polished enterprise solution, but it’s my first real step into development. I encourage other students to try replicating it—it’s the best way to learn! :)

### 🛠️ What is this?
This program is a digital To-Do list for your terminal. It allows you to:
* **Add, Edit, or Delete** tasks quickly.
* **Status Tracking**: Label tasks as `todo`, `in-progress`, or `done`.
* **Auto-Save**: All tasks are stored in a `tasks.json` file, so your data is never lost.

---

### 🚀 Quick Start Guide (Beginner-Friendly)

If you're not a developer and want to see how this works, follow these steps:

#### 1. Get the code
Click the green **"<> Code"** button above and choose **"Download ZIP"**. Unzip the folder on your Desktop.

#### 2. Open the Terminal
Navigate to the folder where `Program.cs` is located. Click on the folder's address bar at the top, type `cmd`, and press **Enter**.
*(Note: You will need the [.NET SDK](https://dotnet.microsoft.com/download) installed to run the commands).*

#### 3. Manage your tasks
Use these commands to interact with your list:

* **Add a task:** `dotnet run -- add "Finish my homework"`
* **View your list:** `dotnet run -- list`
* **Update status to 'Done':** `dotnet run -- mark-done 1`
* **Delete a task:** `dotnet run -- delete 1`

---

### 💻 Behind the Scenes
I built this using:
* **C# / .NET** — Core logic.
* **System.Text.Json** — For saving and reading the task database.
* **CLI Arguments** — To handle user commands directly from the terminal.
