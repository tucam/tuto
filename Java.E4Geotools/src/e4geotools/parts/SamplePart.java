package e4geotools.parts;

import javax.annotation.PostConstruct;

import org.eclipse.e4.ui.di.Focus;
import org.eclipse.swt.SWT;
import org.eclipse.swt.widgets.Composite;
import org.geotools.map.MapContent;
import org.geotools.swt.SwtMapPane;

public class SamplePart {
	private SwtMapPane mapPane;

	@PostConstruct
	public void createComposite(Composite parent) {
		// create map content
		MapContent mapContent = new MapContent();

		// create map view
		mapPane = new SwtMapPane(parent, SWT.BORDER | SWT.NO_BACKGROUND);
		mapPane.setMapContent(mapContent);

		// set the renderer
		// StreamingRenderer renderer = new StreamingRenderer();
		// mapPane.setRenderer(renderer);
	}

	@Focus
	public void setFocus() {
		mapPane.setFocus();
	}

}