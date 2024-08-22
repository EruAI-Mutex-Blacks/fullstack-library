import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
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
import PunishSomeoneOP from './full_pages/OperationsPages/PunishSomeoneOP.jsx'
import ChangeRoleOP from './full_pages/OperationsPages/ChangeRoleOP.jsx'
import BookCreateReqOP from './full_pages/OperationsPages/BookCreateReqOP.jsx'
import BookReadingPage from './full_pages/BookReadingPage.jsx'
import { UserProvider } from './AccountOperations/UserContext.jsx'
import ProtectedRoute from './AccountOperations/ProtectedRoute.jsx'
import PublicRoute from './AccountOperations/PublicRoute.jsx'

//TODO profile page
function App() {
  return (
    <BrowserRouter>
      <UserProvider>
        <div className="d-flex flex-column min-vh-100">
          <header>
            <Navbar />
          </header>
          <main className="flex-fill d-flex bg-custom-primary">
            <Routes>
              <Route exact path="/" element={<Home />}></Route>
              <Route exact path="/Login" element={
                <PublicRoute ><Login /></PublicRoute>
              }></Route>
              <Route exact path="/Register" element={
                <PublicRoute ><Register /></PublicRoute>
              }></Route>
              <Route exact path="/SearchBook" element={
                <ProtectedRoute roles={["member", "staff", "manager"]}>
                  <SearchBookOP />
                </ProtectedRoute>}>
              </Route>
              <Route exact path="/BorrowedBooks" element={
                <ProtectedRoute roles={["member", "staff", "manager"]}>
                  <BorrowedBooksOP />
                </ProtectedRoute>}>
              </Route>
              <Route exact path="/SendMessage" element={
                <ProtectedRoute roles={["member", "staff", "manager"]}>
                  <SendMessageOP />
                </ProtectedRoute>}>
              </Route>
              <Route exact path="/ViewInbox" element={
                <ProtectedRoute roles={["member", "staff", "manager"]}>
                  <ViewInboxOP />
                </ProtectedRoute>}>
              </Route>
              <Route exact path="/ReadBook" element={
                <ProtectedRoute roles={["member", "staff", "manager"]}>
                  < BookReadingPage />
                </ProtectedRoute>}>
              </Route>

              <Route exact path="/BorrowRequests" element={
                <ProtectedRoute roles={["staff", "manager"]}>
                  < BorrowRequestsOP />
                </ProtectedRoute>}>
              </Route>
              <Route exact path="/MemberRegistirations" element={
                <ProtectedRoute roles={["staff", "manager"]}>
                  < MemberRegistirationsOP />
                </ProtectedRoute>}>
              </Route>
              <Route exact path="/PunishSomeone" element={
                <ProtectedRoute roles={["staff", "manager"]}>
                  < PunishSomeoneOP />
                </ProtectedRoute>}>
              </Route>

              <Route exact path="/ChangeRole" element={
                <ProtectedRoute roles={["manager"]}>
                  < ChangeRoleOP />
                </ProtectedRoute>}>
              </Route>
              <Route exact path="/BookCreateRequests" element={
                <ProtectedRoute roles={["manager"]}>
                  < BookCreateReqOP />
                </ProtectedRoute>}>
              </Route>
            </Routes>
          </main>
          <footer className="mt-auto">
            <Footer />
          </footer>
        </div>
      </UserProvider>
    </BrowserRouter >
  )
}

export default App
