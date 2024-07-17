import './App.css'
import { Alert, Container, Row, Col } from 'react-bootstrap'
import React, { useState, useEffect } from 'react'
import axios from 'axios'
import Footer from './components/footer'
import Header from './components/header'
import AddTodoItem from './components/addTodoItem'
import TodoItems from './components/todoItems'

const App = () => {

  const [items, setItems] = useState([])
  const [error, setError] = useState(null);

  useEffect(() => {
    getItems();
  }, [])


  const handleErrorMessage = (error) => {
    setError(error)
    setTimeout(() => {
      setError(null)
    }, 3000)
  }

  //Get Items
  async function getItems() {
    try {
      const response = await axios.get('https://localhost:44397/api/TodoItems');
      setItems(response?.data || []);
    } catch (error) {
      handleErrorMessage(error.response?.data?.message || 'Failed to fetch Todo items. Please try again.')
    }
  }


  //Get Item
  async function handleMarkAsComplete(item) {
    try {
      await axios.put(`https://localhost:44397/api/TodoItems/${item.id}`, { id: item.id, description: item.description, isCompleted: true });
      getItems();
    } catch (error) {
      handleErrorMessage(error.response?.data?.message || 'Failed to mark Todo item as completed. Please try again.')
    }
  }

  return (
    <div className="App">
      <Container>
        <Header />
        <Row>
          <Col>{error && <Alert variant="danger">{error}</Alert>}</Col>
        </Row>
        <Row>
          <Col>
            <AddTodoItem getItems={getItems} handleErrorMessage={handleErrorMessage} />
          </Col>
        </Row>
        <br />
        <Row>
          <Col>
            <TodoItems items={items} getItems={getItems} handleMarkAsComplete={handleMarkAsComplete} />
          </Col>
        </Row>
      </Container>
      <Footer />
    </div>
  )
}

export default App
