import React from 'https://esm.sh/react@18';
import ReactDOM from 'https://esm.sh/react-dom@18';
import { BrowserRouter, Routes, Route, Link } from 'https://esm.sh/react-router-dom@6';

const API_URL = 'http://localhost:5000/api';

function Nav() {
  return (
    <nav className="bg-gray-800 text-white p-4 flex gap-4">
      <Link to="/" className="hover:underline">Dashboard</Link>
      <Link to="/products" className="hover:underline">Products</Link>
      <Link to="/sales" className="hover:underline">Sales</Link>
      <Link to="/inventory" className="hover:underline">Inventory</Link>
      <Link to="/login" className="hover:underline ml-auto">Login</Link>
    </nav>
  );
}

function Dashboard() {
  return <div className="p-4">Dashboard placeholder</div>;
}

function Products() {
  return <div className="p-4">Product catalog placeholder</div>;
}

function Sales() {
  return <div className="p-4">Sales screen placeholder</div>;
}

function Inventory() {
  return <div className="p-4">Inventory management placeholder</div>;
}

function Login() {
  const [username, setUsername] = React.useState('');
  const [password, setPassword] = React.useState('');

  async function handleSubmit(e) {
    e.preventDefault();
    try {
      const res = await fetch(`${API_URL}/Auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
      });
      if (res.ok) {
        const data = await res.json();
        localStorage.setItem('token', data.token);
        alert('Logged in!');
      } else {
        alert('Login failed');
      }
    } catch {
      alert('Error connecting to server');
    }
  }

  return (
    <div className="p-4">
      <h2 className="text-xl mb-2">Login</h2>
      <form onSubmit={handleSubmit} className="space-y-2 max-w-sm">
        <input
          className="border p-2 w-full"
          placeholder="Username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
        <input
          type="password"
          className="border p-2 w-full"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <button
          type="submit"
          className="bg-blue-500 text-white px-4 py-2 rounded"
        >
          Login
        </button>
      </form>
    </div>
  );
}

function App() {
  return (
    <BrowserRouter>
      <Nav />
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/products" element={<Products />} />
        <Route path="/sales" element={<Sales />} />
        <Route path="/inventory" element={<Inventory />} />
        <Route path="/login" element={<Login />} />
      </Routes>
    </BrowserRouter>
  );
}

ReactDOM.createRoot(document.getElementById('root')).render(<App />);
