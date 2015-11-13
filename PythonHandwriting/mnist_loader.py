import os, struct
from array import array as pyarray

import numpy as np

class mnist_loader(object):
    """description of class"""

    def load_data(self, fileName, indicies):
        path = os.path.join(".","images",fileName)
        
        file = open(path, "rb")
        magic, size = struct.unpack(">II",file.read(8))
        rows, cols = (0,0)
        data = 0
        indices = range(size)

        if magic == 2051:
            rows,cols = struct.unpack(">IIII",file.read(16))
            data = pyarray("B", file.read())
            images = zeros((N, rows, cols), dtype = uint8)
            for i, index in enumerate(indices):
                images[i] = np.array(data[indices[i]*rows*cols : (indices[i]+1)*rows*cols]).reshape((rows, cols))
            data = images
        elif magic == 2049:
            data = pyarray("b", file.read())
            
        file.close()

        if indicies:
            ret = (indices, data)
        else:
            ret = data
        return ret
