import React from 'react';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <div className="Header-Nav">
          <div className="Header-Nav__Link">
            Strona Główna 1
          </div>
          <div className="Header-Nav__Link">
            Strona Główna 2
          </div>
        </div>
        <div className="Header-Nav">
          <div className="Header-Nav__Link">
            Logowanie
        </div>
          <div className="Header-Nav__Link">
            Wyloguj
          </div>
        </div>
      </header>
      <div className="App-Content">
        This is content
      </div>
    </div>
  );
}

export default App;
