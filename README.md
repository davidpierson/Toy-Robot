# Toy Robot

#### What is this ?

Toy Robot is a C# coding exercise written for Pronamics as part of a position application.  

#### How should this be executed ?

Fetch the repository to a folder of your choice.
- To run with the supplied sample inputs in the "SampleInputs.txt" solution item, simply run the code.
- As coded, the console output will include every command the resulting position, just as if a REPORT was included every line.
- To use your own inputs, alter the first line in Program.cs "#define CMD_LINE_ORIDE" to defeat it e.g. "#define CMD_LINE_ORIDExxxx"
- When run with your own inputs, if no command line argument is supplied, input is from the console. An empty inout line starts the execution.
- Otherwise, the command line parameter is the relative or absolute name of a file of inputs.
- To stop the automatic reporting of position after every line, defeat the "#define REPORT_ALL" on line 5 of Program.cs file. For example "#define REPORT_ALLxxxx"
 
#### Validation of input syntax

Invalid or incomprehensible inputs are reported with an explanatory error message including the failed input and ignored, and do not cancel the run. 

#### Testing

To test this I added the "#define REPORT_ALL" and verified the robot's progress. I have not ever worked in a job position that had any unit testing, such as NUnit, in place.
In practice, the issues we saw there were system-level complex cases that involved a sequence of events over time, often affected by interactions with external systems. These would be a potential target for a whole-of-system test. 
As a result, I've not included any Nunit or similar here. 

## Specification

### Description
- The application is a simulation of a toy robot moving on a square tabletop, 
  of dimensions 5 units x 5 units.
- There are no other obstructions on the table surface.
- The robot is free to roam around the surface of the table, but must be 
  prevented from falling to destruction. Any movement that would result in the 
  robot falling from the table must be prevented, however further valid 
  movement commands must still be allowed.
- Create an application that can read in commands of the following form:

```
PLACE X,Y,F
MOVE
LEFT
RIGHT
REPORT
```

- PLACE will put the toy robot on the table in position X,Y and facing NORTH,
  SOUTH, EAST or WEST.
- The origin (0,0) can be considered to be the SOUTH WEST most corner.
- The first valid command to the robot is a PLACE command, after that, any
  sequence of commands may be issued, in any order, including another PLACE
  command. The application should discard all commands in the sequence until a
  valid PLACE command has been executed.
- MOVE will move the toy robot one unit forward in the direction it is currently
  facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction
  without changing the position of the robot.
- REPORT will announce the X,Y and F of the robot. This can be in any form, but
  standard output is sufficient.
- A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT
  and REPORT commands.
- Input can be from a file, or from standard input, as the developer chooses.
- Provide test data to exercise the application.

### Constraints
The toy robot must not fall off the table during movement. This also includes 
the initial placement of the toy robot. Any move that would cause the robot 
to fall must be ignored.

### Example Input and Output
a)
```
PLACE 0,0,NORTH
MOVE
REPORT
```
Output: `0,1,NORTH`

b)
```
PLACE 0,0,NORTH
LEFT
REPORT
```
Output: `0,0,WEST`

c)
```
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
```
Output: `3,3,NORTH`

#### Toy robot is a very common coding test and I can find heaps of sample code ?

I haven't looked up any sample code for this puzzle and would be amazed if my solution looks familiar to any other.
The coding styles here are a combination of my experiences. I easily adapt to the local practices and we always aimed for a high consistency code base that you could not tell which developer wrote it. 
