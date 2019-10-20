# Atom

---
*By: Nikolaj Brask-Nielsen*
*Alias: Nikcio*

*Project: Atom*
*Project date: End of 2016*

***

## Table of contents:

1. Description
2. Functionality
3. Quick translation guide
4. Deacy types
5. Goal
6. Sources
7. Other

>**DISCLAIMER: The writing in this file may contain spelling errors and/or grammatical errors.**

## Description:
Atom is a program I made at the end of 2016. The function of the program was to find the decay series of any isotope in my dataset ["Atom_container.txt"](../Atom/Source%20Code/Command%20prompt%20Scripts/Atom_container.txt). The dataset was created by hand from the information which can be found on the website: https://www-nds.iaea.org/relnsd/vcharthtml/VChartHTML.html

## Functionality:
Atom can perform 3 functions:

1. Find a specified isotope and display all the information about saidisotope. (Example: "U-235")
2. Show all isotopes in the provided dataset.
3. Show the decay series of a specific isotope. (Example: "U-235")

## Quick translation guide:
Atom was originally written for me and therefore include both the English and Danish languages. 
I've therefore written a quick guide to translate the information provided from the program.

Danish | English | Details
-------|---------|------
Navn | Name
Kernetal | Mass number | Protons + Neutrons = Mass number
Protroner | Protons
Neutroner | Neutrons
Radioaktivitet | Radioactivity | I'm refering to the type of decay perfomed by the isotope. See next point "Deacy types".
Find | Find
Henfald | Decay series
Alle | All
Søg | Search
Næste | Next
Isotop | Isotope

## Deacy types:
I use some short notation to describe the decay type so I've made a table to decode the notation:

Short notaion: | Defination
---------------|-----------
A | Alpha decay
B+ | Beta+ decay
B- | Beta- decay
S | Stable
P | Protron emission
SF | Spontaneous fission
N | Neutron emission
? | Unknown

For futher information see: https://www-nds.iaea.org/relnsd/vcharthtml/guide.html#quantities

## Goal:
The goal of Atom was to create a functional program, therefore,  Atom wascreated without any 
industry standards in mind. Atom was also created fairly early in myprogramming career and I 
had at the time no knowledge of any industry standards.

>Atom was developed firstly as a command prompt application, in Visual studio. 
And then later recreated in Unity to get the full GUI interface.

## Sources:
[Data about isotopes](https://www-nds.iaea.org/relnsd/vcharthtml/VChartHTML.html)

## Other
[Watch dataset as table](../Atom/Atom_container.md)

[User guide](../Atom/User_Guide.md)