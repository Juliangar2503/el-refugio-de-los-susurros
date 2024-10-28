# El Refugio de los Susurros

### Descripción
**El Refugio de los Susurros** es un juego de terror interactivo, donde el jugador toma decisiones a lo largo de la trama y explora una mansión maldita. A lo largo de 10 nodos (escenarios), el jugador podrá elegir diferentes acciones que lo llevarán a distintos destinos. Dependiendo de las decisiones, el jugador puede llegar a uno de los tres finales: dos malos (donde el personaje muere) y uno bueno (donde el jugador rompe la maldición y sobrevive).

---

## Estructura de la Historia

### Nodo 1: La entrada
- **Descripción**: Llegas a una mansión abandonada. La puerta principal está entreabierta.
- **Acciones**:
  - Entrar a la mansión → [Nodo 2](#nodo-2-el-vestíbulo-oscuro)
  - Rodear la mansión → [Nodo 3](#nodo-3-el-jardín-lúgubre)

### Nodo 2: El vestíbulo oscuro
- **Descripción**: Un gran vestíbulo con una escalera y una puerta al fondo del pasillo.
- **Acciones**:
  - Subir por las escaleras → [Nodo 4](#nodo-4-el-dormitorio-prohibido)
  - Abrir la puerta al fondo del pasillo → [Nodo 5](#nodo-5-el-sótano-escondido)

### Nodo 3: El jardín lúgubre
- **Descripción**: Al rodear la mansión, encuentras una cabaña desvencijada y un pozo.
- **Acciones**:
  - Inspeccionar la cabaña → [Nodo 6](#nodo-6-la-cabaña-olvidada)
  - Mirar dentro del pozo → [Nodo 7](#nodo-7-el-pozo-maldito)

### Nodo 4: El dormitorio prohibido ( se obtiene una vida extra para poder sobrevivir al nodo 8 )
- **Descripción**: Un dormitorio con un espejo roto que refleja una silueta extraña.
- **Acciones**:
  - Examinar el espejo → [Nodo 8](#nodo-8-el-espejo-de-la-muerte-final-malo)
  - Buscar entre los cajones → [Nodo 9](#nodo-9-la-verdad-oculta)

### Nodo 5: El sótano escondido
- **Descripción**: Un sótano oscuro con un murmullo extraño que viene del fondo.
- **Acciones**:
  - Seguir el murmullo → [Nodo 10](#nodo-10-el-fin-oscuro-final-malo)
  - Buscar una salida alternativa → [Nodo 9](#nodo-9-la-verdad-oculta)

### Nodo 6: La cabaña olvidada
- **Descripción**: Dentro de la cabaña hay un altar con símbolos extraños y un libro polvoriento.
- **Acciones**:
  - Abrir el libro → [Nodo 8](#nodo-8-el-espejo-de-la-muerte-final-malo)
  - Registrar el altar → [Nodo 9](#nodo-9-la-verdad-oculta)

### Nodo 7: El pozo maldito
- **Descripción**: Al mirar dentro del pozo, ves una figura sombría en el fondo.
- **Acciones**:
  - Descender al pozo → [Nodo 10](#nodo-10-el-fin-oscuro-final-malo)
  - Alejarse rápidamente → [Nodo 5](#nodo-5-el-sótano-escondido)

### Nodo 8: El espejo de la muerte (Final malo)
- **Descripción**: Al tocar el espejo, te ves atrapado en una dimensión oscura y mueres.
- **Final**: El personaje muere atrapado en el reflejo de sus propios miedos.

### Nodo 9: La verdad oculta
- **Descripción**: Encuentras un medallón con símbolos antiguos, que parece tener el poder de enfrentar la maldición.
- **Acciones**:
  - Usar el medallón para romper la maldición → [Nodo 11](#nodo-11-la-salvación-final-bueno)
  - Ignorar el medallón → [Nodo 10](#nodo-10-el-fin-oscuro-final-malo)

### Nodo 10: El fin oscuro (Final malo)
- **Descripción**: Las sombras te devoran y mueres en la oscuridad de la mansión.
- **Final**: El personaje muere devorado por la oscuridad que habita en la mansión.

### Nodo 11: La salvación (Final bueno)
- **Descripción**: Con el poder del medallón, las sombras se disuelven y la maldición se rompe.
- **Final**: El personaje sobrevive y escapa de la mansión.

---

## Finales Posibles:
1. **Final malo - Nodo 8**: El personaje muere atrapado en el espejo.
2. **Final malo - Nodo 10**: El personaje es devorado por la oscuridad.
3. **Final bueno - Nodo 11**: El personaje rompe la maldición y sobrevive.

---

### Requerimientos
- Unity 2022 o superior
- C# para la lógica de los nodos y las interacciones del jugador.

---

### Instrucciones
1. Explora la mansión y toma decisiones en cada nodo.
2. Dependiendo de tus elecciones, llegarás a uno de los tres finales.
3. ¡Descubre los secretos del **Refugio de los Susurros** y sobrevive al misterio!
