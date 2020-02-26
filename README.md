# Edgerunner.Dice

A comprehensive dice rolling library designed to simulate any known rpg dice system in existence.
Dice can be rolled by interacting with various library classes or by executing scripting,
written in the DiceScript2.0 scripting language.

**This library is an improved re-design of an earlier library and is not functional quite yet.**

![](https://github.com/wiredwiz/Edgerunner.Dice/workflows/.NET%20Core%202.0/badge.svg)


#### Dice Options Processing Pipeline

ExecuteReRollLogic()\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;🠫\
ExecuteRollStatusUpdateLogic()\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;🠫\
ExecuteAdditionalRollLogic()\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;🠫\
ExecuteSuccessCalculationLogic()\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;🠫\
ExecuteVirtualDiceCreationLogic()\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;🠫\
ExecuteDropKeepLogic()