import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Home from './full_pages/Home.jsx'
import Navbar from './Components/Navbar.jsx'
import Footer from './Components/Footer.jsx'
import 'bootstrap/dist/css/bootstrap.min.css'
import Login from './full_pages/Login.jsx'
import Register from './full_pages/Register.jsx'
import SearchBookOP from './full_pages/OperationsPages/SearchBookOP.jsx'
import BorrowedBooksOP from './full_pages/OperationsPages/BorrowedBooksOP.jsx'
import SendMessageOP from './full_pages/OperationsPages/SendMessageOP.jsx'
import ViewInboxOP from './full_pages/OperationsPages/ViewInboxOP.jsx'
import BorrowRequestsOP from './full_pages/OperationsPages/BorrowRequestsOP.jsx'
import MemberRegistirationsOP from './full_pages/OperationsPages/MemberRegistirationsOP.jsx'
import PunishMemberOP from './full_pages/OperationsPages/PunishMemberOP.jsx'
import ChangeRoleOP from './full_pages/OperationsPages/ChangeRoleOP.jsx'
import PunishStaffOP from './full_pages/OperationsPages/PunishStaffOP.jsx'
import BookCreateReqOP from './full_pages/OperationsPages/BookCreateReqOP.jsx'
import BookReadingPage from './full_pages/BookReadingPage.jsx'

function App() {
  //TODO need to allow some roles only can go to some routes
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
            <Route exact path="/SearchBook" element={<SearchBookOP />}></Route>
            <Route exact path="/BorrowedBooks" element={<BorrowedBooksOP />}></Route>
            <Route exact path="/SendMessage" element={<SendMessageOP />}></Route>
            <Route exact path="/ViewInbox" element={<ViewInboxOP />}></Route>
            <Route exact path="/BorrowRequests" element={<BorrowRequestsOP />}></Route>
            <Route exact path="/MemberRegistirations" element={<MemberRegistirationsOP />}></Route>
            <Route exact path="/PunishMember" element={<PunishMemberOP />}></Route>
            <Route exact path="/ChangeRole" element={<ChangeRoleOP />}></Route>
            <Route exact path="/PunishStaff" element={<PunishStaffOP />}></Route>
            <Route exact path="/BookCreateRequests" element={<BookCreateReqOP />}></Route>
            <Route exact path="/ReadBook" element={<BookReadingPage />}></Route>
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
