import React from 'react';
import { Navigate } from 'react-router-dom';
import { useUser } from './UserContext';

const ProtectedRoute = ({ roles, children }) => {
    const { user } = useUser();

    if (!user) {
        return <Navigate to="/Login" />;
    }

    if (roles && !roles.includes(user.role)) {
        return <Navigate to="/unauthorized" />;
    }

    return children;
};

export default ProtectedRoute;