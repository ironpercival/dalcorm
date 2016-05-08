# dalcorm
A tiny helper-wrapper for ORM-like usage of NI.Data.DataRowDalcMapper

For now this tiny package provides simple wrappers for CRUD methods of NI.Data.DataRowDalcMapper class (see 'nreco/nicnet' project on GitHub).
Since NI.Data already has all necessary types/methods to map DB records to objects, this extension simply adds 4 more methods to work with DALC in ORM style. 
Just annotate your domain model entity class with DalcDbTableName custom attribute to specify the DB table; then, annotate necesary properties with DalcDbFieldName attribute to set the table fields mapping.
Now, to get your domain entity objects directly from DALC, use LoadEntity/UpdateEntity/AddEntity/DeleteEntity methods just as normal DataRowDalcMapper CRUD methods.
