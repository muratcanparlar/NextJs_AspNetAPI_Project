CREATE SCHEMA IF NOT EXISTS users
    AUTHORIZATION postgres;

-- Drop existing tables if they exist
DROP TABLE IF EXISTS users.role_permissions CASCADE;
DROP TABLE IF EXISTS users.user_roles CASCADE;
DROP TABLE IF EXISTS users.permissions CASCADE;
DROP TABLE IF EXISTS users.roles CASCADE;
DROP TABLE IF EXISTS users.users CASCADE;

-- Create table for permissions
CREATE TABLE users.permissions (
    code VARCHAR(100) PRIMARY KEY
);

-- Insert default data into permissions table
INSERT INTO users.permissions (code) VALUES
('users:read'),
('users:update'),
('events:read'),
('events:search'),
('events:update'),
('ticket-types:read'),
('ticket-types:update'),
('categories:read'),
('categories:update'),
('carts:read'),
('carts:add'),
('carts:remove'),
('orders:read'),
('orders:create'),
('tickets:read'),
('tickets:check-in'),
('event-statistics:read');

-- Create table for roles
CREATE TABLE users.roles (
    name VARCHAR(50) PRIMARY KEY
);

-- Insert default data into roles table
INSERT INTO users.roles (name) VALUES
('Administrator'),
('Member');

-- Create table for users
CREATE TABLE users.users (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    email VARCHAR(300) NOT NULL,
    first_name VARCHAR(200) NOT NULL,
    last_name VARCHAR(200) NOT NULL,
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    identity_id TEXT NOT NULL UNIQUE
);

-- Create indexes for users table
CREATE UNIQUE INDEX ix_users_email ON users.users (email);
CREATE UNIQUE INDEX ix_users_identity_id ON users.users (identity_id);

-- Create table for role_permissions
CREATE TABLE users.role_permissions (
    permission_code VARCHAR(100),
    role_name VARCHAR(50),
    PRIMARY KEY (permission_code, role_name),
    FOREIGN KEY (permission_code) REFERENCES users.permissions (code) ON DELETE CASCADE,
    FOREIGN KEY (role_name) REFERENCES users.roles (name) ON DELETE CASCADE
);

-- Insert default data into role_permissions table
INSERT INTO users.role_permissions (permission_code, role_name) VALUES
('users:read', 'Member'),
('users:update', 'Member'),
('events:search', 'Member'),
('ticket-types:read', 'Member'),
('carts:read', 'Member'),
('carts:add', 'Member'),
('carts:remove', 'Member'),
('orders:read', 'Member'),
('orders:create', 'Member'),
('tickets:read', 'Member'),
('tickets:check-in', 'Member'),
('users:read', 'Administrator'),
('users:update', 'Administrator'),
('events:read', 'Administrator'),
('events:search', 'Administrator'),
('events:update', 'Administrator'),
('ticket-types:read', 'Administrator'),
('ticket-types:update', 'Administrator'),
('categories:read', 'Administrator'),
('categories:update', 'Administrator'),
('carts:read', 'Administrator'),
('carts:add', 'Administrator'),
('carts:remove', 'Administrator'),
('orders:read', 'Administrator'),
('orders:create', 'Administrator'),
('tickets:read', 'Administrator'),
('tickets:check-in', 'Administrator'),
('event-statistics:read', 'Administrator');

-- Create table for user_roles
CREATE TABLE users.user_roles (
    role_name VARCHAR(50),
    user_id UUID,
    PRIMARY KEY (role_name, user_id),
    FOREIGN KEY (role_name) REFERENCES users.roles (name) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES users.users (id) ON DELETE CASCADE
);

-- Create indexes for role_permissions table
CREATE INDEX ix_role_permissions_role_name ON users.role_permissions (role_name);

-- Create indexes for user_roles table
CREATE INDEX ix_user_roles_user_id ON users.user_roles (user_id);
