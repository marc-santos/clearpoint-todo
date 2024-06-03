import React from 'react';
import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import App from './App';
import userEvent from '@testing-library/user-event';

const mock = new MockAdapter(axios);

const mockItems = [
  { id: 1, description: 'Test Item 1', isCompleted: false },
  { id: 2, description: 'Test Item 2', isCompleted: true },
];

beforeEach(() => {
  mock.reset();
});

test('renders the Todo List App and loads items', async () => {
  // Mock the GET request
  mock.onGet('https://localhost:5001/api/TodoItems').reply(200, mockItems);

  render(<App />);

  // Verify that the app renders the initial items
  await waitFor(() => {
    expect(screen.getByText('Test Item 1')).toBeInTheDocument();
    expect(screen.getByText('Test Item 2')).toBeInTheDocument();
  });
});

test('adds a new todo item', async () => {
  // Mock the GET request
  mock.onGet('https://localhost:5001/api/TodoItems').reply(200, mockItems);
  
  // Mock the POST request
  const newItem = { description: 'Test Item 3', isCompleted: false };
  mock.onPost('https://localhost:5001/api/TodoItems').reply(201, newItem);
  mock.onGet('https://localhost:5001/api/TodoItems').reply(200, [...mockItems, newItem]);

  render(<App />);

  // Simulate user typing a new item description
  userEvent.type(screen.getByPlaceholderText('Enter description...'), 'Test Item 3');

  // Verify that the new item appears in the list
  await waitFor(() => {
    expect(screen.getByText('Test Item 3')).toBeInTheDocument();
  });

  await waitFor(() => {
    expect(screen.getByText('Test Item 1')).toBeInTheDocument();
    expect(screen.getByText('Test Item 2')).toBeInTheDocument();
    expect(screen.getByText('Test Item 3')).toBeInTheDocument();
  });
});