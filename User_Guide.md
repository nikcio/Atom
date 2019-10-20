# User guide

### Table of contents:
1. Unity build
   - Interfaceing with the Unity build
2. Command prompt
---

>**DISCLAIMER: The writing in this file may contain spelling errors and/or grammatical errors.**

#### Unity build
The Unity builds source code can be found in [Unity Build](../Atom/Source%20Code/Unity%20Script). The Source code files include:

1. [Atom_container.txt](../Atom/Source%20Code/Unity%20Script/Atom_container.txt)
2. [Atom_script.cs](../Atom/Source%20Code/Unity%20Script/Atom_script.cs)

The files are taken from a Unity project, therfore, it doesn't include a full project but merly parts of one. The files are meant to give an inside into the functionallity of the program and show how the program was made.

##### Interfaceing with the Unity build
When interfaceing with the [Unity Build exe](../Atom/Builds/Iso_V_1.2.exe) which can be found in the [Builds](../Atom/Builds) folder you'll need some general commands.

On the right there's some buttons where you select which function you want to use. See [README.md](../Atom/README.md) for translation help. 

###### Søg
The søg fuction lets you search for a speciffic isotope. This fuction works by selecting a function and then searching for your desired isotope.

> **Format when searching for isotopes**
> "Short name" + "-" + "Mass number"'
> *Example: "U-235"*
> *Example explanation: U is the short name for Uranium. Then we add a dash (-) before adding the mass number (235)*

To find the short name and mass number for your isotope refer to the dataset [Atom_container.md](../Atom/Atom_container.md)

>**DISCLAIMER: The search bar is case sensitive**

###### Find
The Find button will let you find a speciffic isotope by first selecting the find button and then searching for your isotope.

###### Henfald
The henfald button will show you the decay series for a speciffic isotope by first selecting the button and then searching for your isotope.

###### Alle
The button alle shows you all the isotopes in the dataset and their data. Use the button "næste" to move to the next page.

---

#### Command prompt
In the [Command Prompt directory](../Atom/Source%20Code/Command%20prompt%20Scripts/) you'll find three files:

1. [Atom_class.cs](../Atom/Source%20Code/Command%20prompt%20Scripts/Atom_class.cs)
2. [Program.cs](../Atom/Source%20Code/Command%20prompt%20Scripts/Program.cs)
3. [Atom_container.txt](../Atom/Source%20Code/Command%20prompt%20Scripts/Atom_container.txt)

These files are taken from a project, therefore it doesn't include a full project but merly parts of one. The files are meant to give an inside into the functionallity of the program and show how the program was made.

>**The command prompt was in my testing broken but it includes [Atom_class.cs](../Atom/Source%20Code/Command%20prompt%20Scripts/Atom_class.cs) which is the original script for the functionallity in Atom. In my testing the problem lies in [Program.cs](../Atom/Source%20Code/Command%20prompt%20Scripts/Program.cs) but I haven't thoughly tested for the bug.**
* Bug
  - The console loops in the starting message and doesn't take input from user.

>*I was unable to find the original project files with a working command prompt.*
---