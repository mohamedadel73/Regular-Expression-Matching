# Regular Expression Matching (Naive & Dynamic Programming)

This project implements **regular expression matching** from scratch in **C#**, without using built-in regex libraries.  
The matcher supports the operators:
- `.` → matches any single character
- `*` → matches zero or more occurrences of the previous character

The repository contains **two implementations**:
1. **Naive recursive solution** (backtracking)
2. **Dynamic Programming optimized solution**

---

## Features

- Works with patterns containing `.` and `*`
- Handles edge cases like empty strings and empty patterns
- Demonstrates the difference between recursive and DP approaches
- Clear and commented code for learning purposes

---

## Examples

| Text | Pattern | Match? | Reason |
|-------|---------|--------|--------|
| `aab` | `c*a*b` | ✔️ | `c*` → zero `c`, `a*` → matches `aa`, `b` matches `b` |
| `ab` | `.*` | ✔️ | `.*` can match any sequence |
| `aa` | `a*` | ✔️ | `a*` matches `aa` |
| `ab` | `a*b` | ✔️ | `a*` matches `a` once, then `b` |
| `mississippi` | `mis*is*p*.` | ❌ | last pattern `.` fails |

---
## Naive vs Dynamic Programming

| Approach | Time Complexity | Notes |
|----------|----------------|-------|
| **Naive recursion** | Exponential | Simple but slow with many `*` |
| **Dynamic Programming** | `O(m * n)` | Much faster, avoids repeated work |

---

## What I Learned

- How regex engines match patterns under the hood  
- The difference between backtracking and dynamic programming  
- Why optimization matters for patterns with many repetitions  

---

## Future Improvements

- Add support for `+`, `?`, `[]`, `|` operators  
- Visualize DP table for debugging  
- Convert to NFA/DFA engine later  

---

##  Contributing

Pull requests and issues are welcome!
