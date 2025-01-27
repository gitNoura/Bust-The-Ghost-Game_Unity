# 👻 Bust the Ghost  
## 🎮 Overview  
**Bust the Ghost** is a probability-based game developed in Unity, where players use deductive reasoning and Bayesian inference to locate a hidden ghost within a 7x13 grid. The game challenges players to interpret sensor readings and strategically decide on actions to uncover the ghost’s location before their resources run out.  

[🎥 Watch the YouTube Demo](https://youtu.be/upx52t09c5A?si=XRC8sLTgnTf_pTB_)  

<div align="center">
  <img src="https://github.com/user-attachments/assets/11843495-d148-4aab-be4a-95286612dcda" alt="Image Description">
</div>

---

## 🔍 Introduction  
The project leverages Unity and AI techniques to create a unique gaming experience. Players aim to identify the ghost's location by interpreting sensor feedback, represented as color-coded clues based on the ghost's proximity, and updating posterior probabilities using **Bayesian inference**.  

### Key Features:  
- A 7x13 grid where the ghost is randomly placed using a uniform prior distribution.  
- **Color-coded feedback**:  
  - 🔴 Red: Ghost is in the clicked cell.  
  - 🟠 Orange: 1-2 cells away.  
  - 🟡 Yellow: 3-4 cells away.  
  - 🟢 Green: 5+ cells away.  
- Players lose points (credits) with each click.  
- **Peep Button**: Displays the probability distribution across the grid.  
- **Bust Button**: Allows players to guess the ghost's exact location, leading to either victory or loss.  
<div align="center">
  <img src="https://github.com/user-attachments/assets/97f7b5a7-3faa-40ee-bcf5-a5050a1a021d" alt="Image Description">
</div>


---

## 🎮 Gameplay Mechanics  
1. **Grid Setup**: A 7x13 grid is initialized, with the ghost placed randomly using a uniform probability distribution.  
2. **Sensor Feedback**: Clicking on a cell reveals the proximity of the ghost based on Manhattan distance, indicated by a color.  
3. **Credit System**: Players start with 50 credits, losing 1 per click. Running out of credits results in a loss.  
4. **Peep Mode**: Reveals the probability distribution for the ghost’s location across the grid, aiding decision-making.  
5. **Victory/Loss Conditions**:  
   - **Win**: Guessing the ghost's location correctly using the Bust button.  
   - **Loss**: Depleting credits or running out of allowed bust attempts.  

---

## 🛠️ Unity Environment  
### Tools and Features:  
- **Grid Creation**: Unity’s 2D tools were used to create a 7x13 grid.  
- **Interactive Buttons**:  
  - "Bust" button for guessing the ghost’s location.  
  - "Peep" button for revealing the probability distribution.  
- **Ghost Placement**: Implemented using C# with randomization functions to establish a uniform initial distribution.  
- **UI System**: Real-time credit updates and visual feedback using Unity’s text elements.  
- **Event System**: Captured player inputs (clicks) and triggered corresponding game actions.  

---

## 🤖 Probabilistic Inference  
The game relies on Bayesian inference to calculate the posterior probability of the ghost’s location after each player action.  

### Bayesian Formula:  
\[
P(G \mid S) = \frac{P(S \mid G) \cdot P(G)}{\text{Normalization Factor}}
\]  

Where:  
- \(P(G)\): Prior probability of the ghost’s location.  
- \(P(S \mid G)\): Conditional probability of observing the sensor color given the ghost’s distance.  
- **Normalization**: Ensures the probabilities sum to 1.  

### Conditional Probabilities:  
- 🔴 Red: 0 cells away.  
- 🟠 Orange: 1-2 cells away.  
- 🟡 Yellow: 3-4 cells away.  
- 🟢 Green: 5+ cells away.  

---

## 🧩 Code Highlights  
### Key Components:  
1. **GhostPosition()**:  
   - Places the ghost randomly within the grid using a uniform distribution.  
2. **ColorPosition()**:  
   - Assigns colors (red, orange, yellow, green) to cells based on their distance from the ghost.  
3. **JointTableProbability()**:  
   - Calculates conditional probabilities for each color based on distance.  

### Example:  
```csharp
if (color == "red" && DistanceFromGhost == 0) {
    probability = 0.7;
} else if (color == "orange" && DistanceFromGhost <= 2) {
    probability = 0.5;
}
```
---
### 🕵️ Peep Mode  
- Displays the current probability distribution on the grid when activated.  

---

### ⚠️ Challenges and Insights  

#### Challenges:  
- **Unity Installation**: Initial setup issues delayed development.  
- **C# Proficiency**: Learning and implementing C# within a short timeframe required accelerated effort.  
- **Probabilistic Calculations**: Implementing and normalizing Bayesian inference in real-time.  

#### Insights:  
- Combining Unity’s capabilities with AI techniques created a unique, engaging gameplay experience.  
- Bayesian inference added a strategic layer, encouraging players to use deductive reasoning effectively.  

---

### ✅ Conclusion  
The **Bust the Ghost** project highlights the seamless integration of AI techniques, such as Bayesian inference, with Unity game development. It provides players with an intellectually stimulating experience, showcasing the potential of combining probability-based reasoning with interactive gameplay.  

---

### 📚 References  
1. [Unity Documentation](https://unity.com/)  
2. [Bayesian Inference](https://en.wikipedia.org/wiki/Bayesian_inference)  
3. [YouTube Demo](https://youtu.be/upx52t09c5A?si=XRC8sLTgnTf_pTB_)  
