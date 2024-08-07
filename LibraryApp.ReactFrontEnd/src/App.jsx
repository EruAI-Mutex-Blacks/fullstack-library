import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Home from './full_pages/Home.jsx'
import Navbar from './Navbar.jsx'
import Footer from './Footer.jsx'
import 'bootstrap/dist/css/bootstrap.min.css'
import Login from './full_pages/Login.jsx'
import Register from './full_pages/Register.jsx'

function App() {
  return (
      <BrowserRouter>
        <div className="d-flex flex-column min-vh-100">
          <header>
            <Navbar />
          </header>
          <main className="flex-fill d-flex bg-custom-primary">
            <Routes>
              <Route exact path="/" element={<Home />}></Route>
              <Route exact path="/Login" element={<Login />}></Route>
              <Route exact path="/Register" element={<Register />}></Route>
            </Routes>
          </main>
          <footer className="mt-auto">
            <Footer />
          </footer>
        </div>
      </BrowserRouter>
  )
}

export default App
