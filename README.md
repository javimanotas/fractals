# Fractals

A **2D and 3D real-time fractal rendering program** developed with Unity.

Screenshots are saved into [Application.dataPath](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Application-dataPath.html).

> [!WARNING]  
> Even though the program is optimized, enabling high-quality settings can result in very expensive GPU calls, which might cause the program to crash. Please read this document carefully before using the program and try rendering in multiple frames if you are not sure about the computational impact of certain parameters.

---

## 2D Fractals

### Screenshots
![Mandelbrot Set](Assets/Screenshots/Mandelbrot.png)  
*Mandelbrot Set Example*

![Julia Set](Assets/Screenshots/Julia.png)  
*Julia Set Example*

### Fractal Equation

The fractals are defined using the following recursive series:

$$ f_0 = z $$  
$$ f_{n+1} = p(f_n) + f_0 $$

- `p` is a polynomial, which defaults to `p(x) = x^2`.
- `z` is the point in the complex plane you want to calculate the color for.

If the **Julia mode** is enabled, the equation is modified as follows:

$$ f_0 = z $$  
$$ f_{n+1} = p(f_n) + c $$

- `c` is a constant value applied uniformly across all points.
---

### Navigation and Interaction

- Use the **left mouse button** to move around the fractal.
- Use the **mouse wheel** to zoom in and out.
- Use the **right mouse button** by dragging to zoom in a rectangular region.
- Alternatively, you can use the **UI input fields** to navigate.
- The complex plane can be **inverted** (raising all points to the power of `-1`).

---

### Rendering

Unfortunately, not all platforms or hardware support double precision on decimal values in compute shaders. Platforms different from Windows will use floating 32 bit floatint point. Windows will use instead 64 bits so if your architecture doesn't support it you will see a black screen.

---

## 3D Fractals

### Screenshots
![3D Mandelbulb](Assets/Screenshots/Mandelbulb.png)  
*Mandelbulb Example*

![3D Julia (Green)](Assets/Screenshots/3DGreenJulia.png)  
*Green 3D Julia Example*

![3D Julia (Orange)](Assets/Screenshots/3DOrangeJulia.png)  
*Orange 3D Julia Example*

---

### Rendering Technique

The 3D fractals are rendered using a technique called [ray marching](https://iquilezles.org/articles/raymarchingdf/), which uses **signed distance functions (SDFs)**. These [SDFs](https://iquilezles.org/articles/distfunctions/) are derived from their 2D fractal counterparts.

> [!TIP]  
> 3D fractals may lose significant detail at medium or low resolutions (e.g., 1080p or lower). To achieve sharper visuals, increase the resolution scale in the settings to more than 100%.

---

### Navigation and Interaction

- Use WASD to move the camera forward/backward and to the right/left.
- Use QE to move the camera up/down.
- Use arrow keys to rotate the camera.
- Use the **mouse wheel** to zoom in and out.
